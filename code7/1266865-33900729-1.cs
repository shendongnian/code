    public class ViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<Person> List { get; set; }
            Person currentPerson;
            public Person CurrentPerson {
                get { return currentPerson; }
                set { currentPerson = value;
                FirePropertyChanged("CurrentPerson");
                }
            }
    
            private void FirePropertyChanged(string v)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
            public event PropertyChangedEventHandler PropertyChanged;
            
        }
