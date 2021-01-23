      public class DataGridMAinViewModel:BaseObservableObject
    {
        public DataGridMAinViewModel()
        {
            ServerDataCollection = new ObservableCollection<Server>(new List<Server>
            {
                new Server { 
                    ServerName = "^1Gun^3Money",
                Players = "0/16", Map = "ut4_asd", GameType = "FFA", Ip = "127.0.0.0:27960" },
                 new Server { ServerName = "^2Gun^1Money",
                Players = "0/16", Map = "ut4_asd", GameType = "FFA", Ip = "127.0.0.0:27960" },
                 new Server { ServerName = "^2Gun^3Money",
                Players = "0/16", Map = "ut4_asd", GameType = "FFA", Ip = "127.0.0.0:27960" },
            });
        }
        public ObservableCollection<Server> ServerDataCollection { get; set; }
    }
