      public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    InitializeComponent();
                    List<DataItem> data = new List<DataItem>();
                    data.Add(new DataItem { Track = "a.1", Artist = "a.2", Album = "a.3", Time = "a.4" });
                    data.Add(new DataItem { Track = "a.1", Artist = "a.2", Album = "a.3", Time = "a.4" });
                    data.Add(new DataItem { Track = "a.1", Artist = "a.2", Album = "a.3", Time = "a.4" });
                    trackList.ItemsSource = data;
                }
         
            }
            public class DataItem
            {
                public string Track { get; set; }
                public string Artist { get; set; }
                public string Album { get; set; }
                public string Time { get; set; }
            }
