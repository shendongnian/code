     class MainViewModel : INotifyPropertyChanged
        {
            private string _name;
    
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    Debug.WriteLine(value);
                    OnPropertyChanged();
                }
            }
    
            public MainViewModel()
            {
                Task.Factory.StartNew(async () =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
    
                        Name = i.ToString();
                        await Task.Delay(3000);
                    }
                });
            }
    
    
            public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
