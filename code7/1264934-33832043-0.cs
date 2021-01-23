     public class ViewModel: INotifyPropertyChanged
     {
                private string _type;
                public string Type 
                {
                    get { return _type; } 
                    set 
                    {
                        _type = value;
                        OnPropertyChanged("Type");
                    }
                }
                public event PropertyChangedEventHandler PropertyChanged;
                protected virtual void OnPropertyChanged(string propertyName = null)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
    }
