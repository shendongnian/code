    class Class1:INotifyPropertyChanged
        {
            private string _val;
            public string val
            {
                get
                {
                    return this._val;
                }
                set
                {
                    if (this._val != value)
                    {
                        this._val = value;
                        NotifyPropertyChanged("");
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
