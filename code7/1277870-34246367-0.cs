    class MyClass : INotifyPropertyChanged
        {
          public bool MyProperty{ get; set; }
        
          public event PropertyChangedEventHandler PropertyChanged;
        
          protected void OnPropertyChanged(string name)
          {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
              handler(this, new PropertyChangedEventArgs(name));
             }
          }
        
        }
To notify any property change you have to use:
    OnPropertyChanged("MyProperty");
