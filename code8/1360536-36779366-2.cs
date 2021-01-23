     public class ThreeColumnList : INotifyPropertyChanged
        {
            private string name = string.Empty;
            public string Name { get { return name; } set { name = value; NotifyPropertyChanged("Name"); } }
    
            private string age = string.Empty;
            public string Age { get { return age; } set { age = value; NotifyPropertyChanged("Age"); } }
    
            private string job = string.Empty;
            public string Job { get { return job; } set { job = value; NotifyPropertyChanged("Job"); } }
    
            //PropertyChanged handers
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs(propertyName));
                }
            }
        }
