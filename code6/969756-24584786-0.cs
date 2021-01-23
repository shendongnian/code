    public partial class Form1 : Form
    {
        Graphics drawingarea;
        int x1, y1,x2,y2 = 0;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool GetCursorPos(ref Point lpPoint);
        public Form1()
        {
            InitializeComponent();
            drawingarea = drawbox.CreateGraphics();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Pen blackpen = new Pen(Color.Black);
            x1 = Convert.ToInt32(textBox1.Text);
            y1 = Convert.ToInt32(textBox2.Text);
            //x2 = Convert.ToInt32(textBox3.Text);
            //y2 = Convert.ToInt32(textBox4.Text);
            drawingarea.DrawLine(blackpen, x1, y1, x2, y2);
        }
        protected override void OnMouseMove( MouseEventArgs e)
        {
            Point p = GetCursorPosition();
            x2 = p.X;
            y2 = p.Y;
            label6.Location = new Point(x2, y2);
            base.OnMouseMove(e);
        }
        public static Point GetCursorPosition()
        {
            Point p = new System.Drawing.Point(0, 0);
            GetCursorPos(ref p);
            return p;
            }
    }
