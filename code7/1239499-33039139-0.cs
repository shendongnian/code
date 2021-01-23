    public Form1()
        {
            InitializeComponent();
        }
        private List<Point> points = new List<Point>(); 
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            Point rp = new Point(mouseEventArgs.X, mouseEventArgs.Y);
            points.Add(rp);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllLines("c:\\temp\\new.txt", points.Select(point => "X: " + point.X + "  Y: " + point.Y));
        }
