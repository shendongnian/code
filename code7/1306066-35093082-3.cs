    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private List<NamedayModel> namedays = new List<NamedayModel>();
        public List<NamedayModel> Namedays { get { return namedays; } set { namedays = value; RaiseProperty(nameof(Namedays)); } }
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.Loaded += MainPage_Loaded;
        }
        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Namedays = await GetAllNamedaysAsync();
        }
        public static async Task<List<NamedayModel>> GetAllNamedaysAsync()
        {
            if (allNamedaysCache != null)
                return allNamedaysCache;
            var client = new HttpClient();
            var stream = await client.GetStreamAsync("http://www.tyosoft.com/namedays_hu.json");
            var serializer = new DataContractJsonSerializer(typeof(List<NamedayModel>));
            allNamedaysCache = (List<NamedayModel>)serializer.ReadObject(stream);
            return allNamedaysCache;
        }
    }
