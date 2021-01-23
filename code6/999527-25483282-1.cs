    public class Seat
    {
        public string available { get; set; }
        public string baseFare { get; set; }
        public string serviceTaxAbsolute { get; set; }
        public Seat() { }
    }
    string text = "[{\"available\":\"true\",\"baseFare\":\"600\",\"serviceTaxAbsolute\":\"0\"},{\"available\":\"true\",\"baseFare\":\"600\",\"serviceTaxAbsolute\":\"0\"}]";
    List<Seat> seats = new List<Seat>();
    public MainPage()
    {
         this.InitializeComponent();
         seats = JsonConvert.DeserializeObject<List<Seat>>(text);
    }
