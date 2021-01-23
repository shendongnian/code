    public partial class Form1 : Form
    {
        private readonly Random r = new Random();
        private int start_x = 0;
        private int start_y = 0;
        private int end_x = 0;
        private int end_y = 0;
        private int fly_x = 0;
        private int fly_y = 0;
        private int clicks = 0;
        private int distance = 0;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            label1.Text = "clicks: 0";
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            clicks++;
            if (clicks == 1)
            {
                start_x = e.X;
                start_y = e.Y;
            }
            else if (clicks == 2)
            {
                end_x = e.X;
                end_y = e.Y;
            }
            else if (clicks == 3)
            {
                fly_x = e.X;
                fly_y = e.Y;
                timer1.Start();
            }
            else if (clicks == 4)
            {
                timer1.Stop();
                clicks = 0;
            }
            label1.Text = "clicks: " + clicks;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (clicks == 1)
            {
                e.Graphics.DrawEllipse(Pens.Black, start_x - 2, start_y - 2, 4, 4);
            }
            else if (clicks == 2)
            {
                distance = Distance(start_x, start_y, end_x, end_y);
                e.Graphics.DrawEllipse(Pens.Black, start_x - 2, start_y - 2, 4, 4);
                e.Graphics.DrawEllipse(Pens.Black, start_x - distance, start_y - distance, distance * 2, distance * 2);
            }
            else if (clicks == 3)
            {
                e.Graphics.DrawEllipse(Pens.Black, start_x - 2, start_y - 2, 4, 4);
                e.Graphics.DrawEllipse(Pens.Black, start_x - distance, start_y - distance, distance * 2, distance * 2);
                e.Graphics.FillEllipse(Brushes.Red, fly_x - 3, fly_y - 3, 6, 6);
            }
        }
        private int Distance(int a_x, int a_y, int b_x, int b_y)
        {
            int a, b;
            a = a_x - b_x;
            b = a_y - b_y;
            return (Convert.ToInt32(Math.Sqrt(a * a + b * b)));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            fly_x = fly_x + r.Next(-4, 5);
            fly_y = fly_y + r.Next(-4, 5);
            if (Distance(start_x, start_y, fly_x, fly_y) > distance - 1)
            {
                if (fly_x < start_x)
                {
                    fly_x = fly_x + 5;
                }
                else
                {
                    fly_x = fly_x - 5;
                }
                if (fly_y < start_y)
                {
                    fly_y = fly_y + 5;
                }
                else
                {
                    fly_y = fly_y - 5;
                }
            }
            Invalidate();
        }
    }
