    public class ServerModel
    {
        public string Name { get; set; }
        public string IP { get; set; }
    }
    public class ServerViewModel : ViewModelBase
    {
        private ServerModel model;
        public ServerViewModel(ServerModel model)
        {
            this.model = model;
        }
        
        public string Name
        {
             get { return model.Name; }
             private set
             {
                  model.Name = value;
                  OnPropertyChanged("Name");
             }
        }
        public string IP
        {
             get { return model.IP; }
             private set
             {
                  model.IP= value;
                  OnPropertyChanged("IP");
             }
        }
    }
