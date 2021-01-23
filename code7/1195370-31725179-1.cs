    public class Car
    {
        public Size Size { get; set; }
        public Color Color { get; set; }
        public Point Location { get; set; }
        public int Speed { get; set; }
        // and whatever you need, eg. direction, etc.
    }
    private List<Car> cars;
    public Form1()
    {
        InitializeComponent();
        cars = new List<Car>
        {
            new Car { Size = new Size(30, 15), Color = Color.Blue, Location new Point(100, 100), Speed = 1 },
            new Car { Size = new Size(50, 20), Color = Color.Red, Location = Point(200, 150), Speed = 3 },
        };
    }
    private void btnStart_Click(object sender, EventArgs e)
    {
        timer1.Interval = 100; // animation speed
        timer1.Enabled = true; // starting animation
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        foreach (Car car in cars)
            RecalculateLocation(car); // update Location by speed here
        panel1.Invalidate();
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        // now we are just drawing colored rectangles but you can draw car.Image or anything you want
        foreach (Car car in cars)
        {
            using (Brush brush = new SolidBrush(car.Color))
            {
                e.Graphics.FillRectangle(brush, new Rectangle(car.Location, car.Size));
            }
        }
    }
