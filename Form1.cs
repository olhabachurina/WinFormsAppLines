namespace WinFormsAppLines
{
    public partial class Form1 : Form
    {
        private Point startPoint;
        private Point endPoint;
        private List<Point> lines=new List<Point>();
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            this.Paint += Form1_Paint;
        }
            private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Red, 2))
            {
                for (int i = 0; i < lines.Count; i += 2)
                {
                    e.Graphics.DrawLine(pen, lines[i], lines[i + 1]);
                }
            }
            
            if (startPoint != Point.Empty && endPoint != Point.Empty)
            {
                using (Pen tempPen = new Pen(Color.Gray, 2))
                {
                    e.Graphics.DrawLine(tempPen, startPoint, endPoint);
                }
            }
        }
        private void Form1_MouseUp(object? sender, MouseEventArgs e)
        {
            endPoint = e.Location;
            lines.Add(startPoint);
            lines.Add(endPoint);
            this.Invalidate(); 
        }
                private void Form1_MouseMove(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                endPoint = e.Location;
                this.Invalidate(); 
            }
        }
        private void Form1_MouseDown(object? sender, MouseEventArgs e)
        {
            startPoint = e.Location;
        }
    }
}