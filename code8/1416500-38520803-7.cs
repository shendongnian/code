    namespace app1
    {
    public class info
    {
        public String name { get; set; }
        public String bio { get; set; }
        public String image { get; set; }
    }
    
    public sealed partial class abcde : Page
    {
    
        ObservableCollection<info> obsinfo = new ObservableCollection<info>();
        public abcde()
        {
            this.InitializeComponent();
            filldata();
        }
        void filldata()
        {
            obsinfo.Add(new info { name = "data1", image = "images/data1.png", bio = "" });
            obsinfo.Add(new info { name = "data2", image = "images/data2.png", bio = "" });
        
         }
         
         // Here we can set ItemsSource for our ListView
         private void Data_Loaded(object sender, RoutedEventArgs e) {
                    var listView = (ListView)sender;
                    listView.ItemsSource = obsinfo;
         }
    
      }
    }
