    public partial class Form_GPS : Form
    {
        public Form_GPS(Form1 owner)
        {
            InitializeComponent();
    		owner.GpsUpdated += new Form1.GpsUpdateHandler(gps_updated);
        }
    
        private void Form_GPS_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("GPS Form loaded");
        }
    
        // handles the event from Form1
        private void gps_updated(object sender,GpsUpdateEventArgs e)
        {
            Debug.WriteLine("Event fired");
            Debug.WriteLine(e.Lat.ToString());
        }
    }
