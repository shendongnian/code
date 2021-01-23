    public partial class Form1 : Form
    {
        GeoCoordinateWatcher GEOWatcher;
        public Form1()
        {
            InitializeComponent();
            // this will start the GeoCoordinateWatcher when the app starts
            GEOWatcher = new GeoCoordinateWatcher();
            GEOWatcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetLocation();
        }
        static void GetLocation()
        {
            GeoCoordinate Coordinates = GEOWatcher.Position.Location;
            if (Coordinates.IsUnknown != true)
            {
                Console.WriteLine("Latitude: " + Coordinates.Latitude + ", Longitude: " + Coordinates.Longitude);
                Console.WriteLine("https://www.google.co.uk/#q=" + Coordinates.Latitude + "," + Coordinates.Longitude);
            }
            else
            {
                Console.WriteLine("Location currently unavaliable");
            }
        }
    }
