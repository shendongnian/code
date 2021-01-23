     public class HierachicalGroup: INotifyPropertyChanged
        {
            public virtual string Name { get; set; }
            public virtual HierachicalGroup[] Children { get; set; }
            public virtual HierachicalGroup Parent { get; set; }
    
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
    
    
            private bool _isExpanded;
            public bool IsExpanded
            {
                get { return _isExpanded; }
                set
                {
                    if (value != _isExpanded)
                    {
                        _isExpanded = value;
                        this.OnPropertyChanged("IsExpanded");
                    }
    
                    // Expand all the way up to the root.
                    if (_isExpanded && Parent != null)
                        Parent.IsExpanded = true;
                }
            }
    
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
            #endregion // INotifyPropertyChanged Members
       }
