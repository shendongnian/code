    public partial class LocationAndQuantity : UserControl
    {
        public Brush Color { get; set; }
        public string  Location { get; set; }
        public int Quantity { get; set; }
        public LocationAndQuantity(Color c,string l, int q)
        {
            this.Color = new SolidColorBrush(c);
            this.Location = l;
            this.Quantity = q;
            InitializeComponent();
            DataContext = this;            
        }
    }
