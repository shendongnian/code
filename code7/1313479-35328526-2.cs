    public class ViewModel: BindableBase
    {
        private Sessions _sessions;
        public Sessions sessionsCollection
        {
           get { return _sessions; }
        }
        public Session SelectedSession
        {
            get;set; //properly implemented with the INotifyPropertyChanged
        }
    
        public ViewModel()
        {
          sessionsCollection = allSessions();
        }
    
        public Sessions allSessions()
        {
                    var custom = new Sessions();//notice this is already a collection
                    custom.Add(new Session() { name = "LocateSession", value = 10 }); //System.Null Reference Exception.
                    custom.Add(new Session() { name = "TrackSession", value = 20 });
                    custom.Add(new Session() { name = "MonitorSession", value = 25 }); 
                    custom.Add(new Session() { name = "MassSnapshot", value = 18 });
                    custom.Add(new Session() { name = "MassContinuous", value = 9 });
                    return custom;
                }
    }
