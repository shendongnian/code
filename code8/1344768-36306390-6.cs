    public class Class1:INotifyPropertyChanged
        {
            
            int screenWidth;
            public int ScreenWidth
            {
                get
                {
                    return screenWidth;
                }
                set
                {
                    if(value!=screenWidth)
                    {
                        screenWidth = value;
                        OnPropertyChanged("ScreenWidth");
                    }
                }
               
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                // the new Null-conditional Operators are thread-safe:
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
