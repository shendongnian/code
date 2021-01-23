      public class Team : INotifyPropertyChanged
        {
            private string _name;
            private string _city;
            private List<Player> _players;
    
            public string Name
            {
                get { return _name; }
            }
    
            public string City
            {
                get { return _city; }
            }
    
            public List<Player> Players
            {
                get { return _players; }
                set { 
                    _players =value;
                    RaisePropertyChanged("Players");
                }
            }
    
    
            #region INotifyPropertyChanged
    
            internal void RaisePropertyChanged(string prop)
            {
                if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
            }
            public event PropertyChangedEventHandler PropertyChanged;
    
            #endregion
    
        }
        public class Player
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
