    public class MyModel: INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            private object _id;
            public object ID 
            {
                get { return _id; }
                set 
                { 
                    _id = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("ID"));
                }
            }
    
            private object _selectedItem;
            public object SelectedItem
            {
                get { return _selectedItem; }
                set
                {
                    _selectedItem = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("SelectedItem"));
                }
            }
    
            public virtual void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, e);
            }
        }
