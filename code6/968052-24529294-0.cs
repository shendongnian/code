     // This is a simple Clients class that  
        // implements the IPropertyChange interface. 
        public class Clients: INotifyPropertyChanged
        {
            // These fields hold the values for the public properties. 
            private bool isChecked = false;
            private string title = String.Empty;
            private string first_name = String.Empty;
            private string last_name = String.Empty;
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            // This method is called by the Set accessor of each property. 
            // The CallerMemberName attribute that is applied to the optional propertyName 
            // parameter causes the property name of the caller to be substituted as an argument. 
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            // The constructor is private to enforce the factory pattern. 
            private Clients()
            {
    
            }
    
            // This is the public factory method. 
            public static Clients CreateNewCustomer()
            {
                return new Clients();
            }
    
            // This property represents an ID, suitable 
            // for use as a primary key in a database. 
            public bool IsChecked 
            {
                get
                {
                    return this.isChecked;
                }
    
                set
                {
                    if (value != this.isChecked)
                    {
                        this.isChecked = value;
                        NotifyPropertyChanged();
                    }
                }
            }
    
            public string Title
            {
                get
                {
                    return this.title;
                }
    
                set
                {
                    if (value != this.title)
                    {
                        this.title = value;
                        NotifyPropertyChanged();
                    }
                }
            }
    
            public string FirstName
            {
                get
                {
                    return this.first_name;
                }
    
                set
                {
                    if (value != this.first_name)
                    {
                        this.first_name = value;
                        NotifyPropertyChanged();
                    }
                }
            }
    
            public string LastName
            {
                get
                {
                    return this.last_name;
                }
    
                set
                {
                    if (value != this.last_name)
                    {
                        this.last_name = value;
                        NotifyPropertyChanged();
                    }
                }
            }
        }
