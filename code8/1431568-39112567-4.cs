     public event PropertyChangedEventHandler PropertyChanged;
    
            public void NotifyPropertyChanged([CallerMemberName] string propertyName =null)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
