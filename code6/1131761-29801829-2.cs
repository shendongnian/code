    namespace WpfApplication1
    {
        class ViewModel : INotifyPropertyChanged
        {
            private string myVar;
    
            public string MyVal
            {
                get
                {
                    return myVar;
                }
                set
                {
                    if (value.Length > 6)
                        myVar = value;
                    else
                        myVar = "Not a valid INPUT";
                   NotifyPropertyChanged("MyVal");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
    
    
            public ViewModel() { }
        }
    }
