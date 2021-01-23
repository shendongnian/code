    public class Stone : INotifyPropertyChanged
        {
            private static int _CountStones;
            public static int CountStones
            {
                get { return _CountStones; }
            }
    
            private Boolean _Color;
            public Boolean Color
            {
                get { return _Color; }
                set {
                    if (value == _Color)
                        return;
    
                    _Color = value;
    
                    OnPropertyChanged("Color");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
