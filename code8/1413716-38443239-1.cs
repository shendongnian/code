    public class Pony : INotifyPropertyChanged
        {
            public int Id {
                get; set;
            }
            private string _name;
            public string Name {
                get { return this._name; }
                set { this._name = value;
                    this.OnPropertyChanged("Name");
                }
            }
    
            public Brush Color { get; set; }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
