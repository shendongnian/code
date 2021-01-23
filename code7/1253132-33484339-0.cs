    interface IShape
    {
        Pen Pen { get; set; }
        Brush Fill { get; set; }
        void Draw(Graphics g);
        bool IsHit(PointF p);
    }
    class Line : IShape
    {
        public Brush Fill { get; set; }
        public Pen Pen { get; set; }
        public PointF Start { get; set; }
        public PointF End { get; set; }
        public void Draw(Graphics g)
        {
            g.DrawLine(Pen, Start, End);
        }
        public bool IsHit(PointF p)
        {
            // Find distance to the end points
            var d1 = Math.Sqrt((Start.X - p.X) * (Start.X - p.X) + (Start.Y - p.Y) * (Start.Y - p.Y));
            var d2 = Math.Sqrt((End.X - p.X) * (End.X - p.X) + (End.Y - p.Y) * (End.Y - p.Y));
            // https://en.wikipedia.org/wiki/Distance_from_a_point_to_a_line
            var dx = End.X - Start.X;
            var dy = End.Y - Start.Y;
            var length = Math.Sqrt(dx * dx + dy * dy);
            var distance = Math.Abs(dy * p.X - dx * p.Y + End.X * Start.Y - End.Y * Start.X) / Math.Sqrt(dy * dy + dx * dx);
            // Make sure the click was really near the line because the distance above also works beyond the end points
            return distance < 3 && (d1 < length + 3 && d2 < length + 3);
        }
    }
    public partial class Form1 : Form
    {
        private ObservableCollection<IShape> shapes = new ObservableCollection<IShape>();
        private static Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            shapes.CollectionChanged += Shapes_CollectionChanged;
        }
        private void Shapes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Redraw();
        }
        public void Redraw()
        {
            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                foreach (var shape in shapes)
                {
                    shape.Draw(g);
                }
            }
            pictureBox1.Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            shapes.Add(new Line
            {
                Pen = Pens.Red,
                Start = new PointF(random.Next(pictureBox1.Width), random.Next(pictureBox1.Height)),
                End = new PointF(random.Next(pictureBox1.Width), random.Next(pictureBox1.Height))
            });
        }
        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Redraw();
        }
        private IShape FindShape(PointF p)
        {
            // Reverse search order because we draw from bottom to top, but we need to hit-test from top to bottom.
            foreach (var shape in shapes.Reverse())
            {
                if (shape.IsHit(p))
                    return shape;
            }
            return null;
        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            var shape = FindShape(e.Location);
            if (shape != null)
            {
                shape.Pen = Pens.Blue;
                Redraw();
            }
        }
    }
