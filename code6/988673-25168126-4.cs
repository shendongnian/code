    using System.Windows;
    using System.Collections.ObjectModel;
    using Newtonsoft.Json.Linq;
    namespace MyWpfApplication
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
    
                // Your JSON string
                const string json = 
                    "{'xId':'52'," +
                    "  'result':{" + 
                    "    'type':'Basico.Bean.MunicipioClass.TMunicipio'," +
                    "    'id':1," + 
                    "    'fields':{" + 
                    "      'FRefCount':0," +
                    "      'FId':52," + 
                    "      'FNome':'Sumare'," + 
                    "      'FEstado':'SP'," + 
                    "      'FPais':'Brasil'" + 
                    "    }" + 
                    "  }" + 
                    "}";
    
                // Parse as JObject
                JObject jObj = JObject.Parse(json);
    
                // Extract what you need, the "fields" property
                JToken jToken = jObj["result"]["fields"];
    
                // Convert as Fields class instance
                Fields fields = jToken.ToObject<Fields>();
    
                // Assign to Items property, this is the ListBox ItemsSource
                Items = new ObservableCollection<Fields>() { fields };
            }
            public ObservableCollection<Fields> Items { get; set; }
        }
    }
