    class SomeClass : INotifyPropertyChanged
    {
        private int foo;
    
        public event PropertyChangedEventHandler PropertyChanged;
        public int Foo
        {
           get { return foo; }
           set
           {
              if (foo == value)
                 return;
              foo = value;
              PropertyChanged("Foo");
           }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
