    public class ListItems 
        {
            
            MyType _selectedType;
            public MyType SelectedDataType
            {
                get { return _selectedType; }
                set
                {
                    _selectedType = value;
                    this.NotifyPropertyChanged("SelectedDataType");
                }
            }
        }
