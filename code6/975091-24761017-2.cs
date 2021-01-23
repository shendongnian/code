     public class Item: HierachicalGroup, INotifyPropertyChanged
        {
            public Domain Domain { get; set; }
    
            public override string Name
            {
                get
                {
                    return Domain.DomainName;
                }
                set
                {
                    //not doing it :)
                }
            }
    
            private bool _isSelected;
            public bool IsSelected
            {
                get { return _isSelected; }
                set
                {
                    if (value != _isSelected)
                    {
                        _isSelected = value;
                        this.OnPropertyChanged("IsSelected");
                    }
                }
            }
    
            private void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, e);
            }
    
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
