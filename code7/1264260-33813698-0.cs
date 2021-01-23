    public partial class CustomControl1 : Control
    {
        public CustomControl1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            timer1.Enabled = true;
            timer1.Interval = 1;
            xSpeed = 5;
            ySpeed = 5;
            ballRect = new Rectangle(10, 10, 20, 20);
            brush = new SolidBrush(Color.Red);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.FillEllipse(brush, ballRect);
        }
        int xSpeed, ySpeed;
        Brush brush;
        Rectangle ballRect;
        private void timer1_Tick(object sender, EventArgs e)
        {
            ballRect.X += xSpeed;
            ballRect.Y += ySpeed;
            if (ballRect.X + ballRect.Width >= this.Width)
                xSpeed = -xSpeed;
            if (ballRect.Y + ballRect.Height >= this.Height)
                ySpeed = -ySpeed;
            if (ballRect.X <= 0)
                xSpeed = -xSpeed;
            if (ballRect.Y <= 0)
                ySpeed = -ySpeed;
            this.Invalidate();
        }
    }
