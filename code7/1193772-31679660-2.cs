    public class PersonViewModel: INotifyPropertyChanged
    {
        public PersonViewModel()
        {
            /*You could initialize Person from data store or create new here but not necessary. 
            It depends on your requierements*/
            Person = new Person(); 
        }
        
        private Person person;
        public Person Person{ 
            get {return person;}
            set { 
                if ( person != value){ 
                    person = value;
                    OnPropertyChanged()
                }
            }
        }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
            {
                var eventHandler = this.PropertyChanged;
                if (eventHandler != null)
                {
                    eventHandler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    }
