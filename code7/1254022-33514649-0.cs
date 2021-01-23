           private string time;
           public string Time 
           {
               get 
                {
                   return this.time;
                }
                set
                {
                   this.time = value;
                   NotifyPropertyChanged("Time");
                }
             }
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
