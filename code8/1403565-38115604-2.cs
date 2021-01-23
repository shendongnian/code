    public partial class LocationAndQuantity : UserControl
    {
        public Brush Color { get; set; }
        public string  Location { get; set; }
        public int Quantity { get; set; }
        //The class must have default constructor
        public LocationAndQuantity()
        {
            this.InitializeComponent();
        }
        public LocationAndQuantity(string c,string l, int q)
        {
            this.Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(c));
            this.Location = l;
            this.Quantity = q;
            InitializeComponent();
            DataContext = this;            
        }
    }
