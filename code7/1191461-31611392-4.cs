    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;
            TopMost = true;
            TransparencyKey = BackColor;
            timer1.Tick += timer1_Tick;
        }
        Timer timer1 = new Timer() { Interval = 15, Enabled = true};
        
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawTest(e.Graphics);
            base.OnPaint(e);
        }
        private void DrawTest(Graphics g)
        {
            var p = PointToClient(Cursor.Position);
            g.DrawEllipse(Pens.DeepSkyBlue, p.X - 150, p.Y - 150, 300, 300);
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
