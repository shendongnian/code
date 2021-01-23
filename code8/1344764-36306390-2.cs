    Class1 vm;
            public Class1 Vm
            {
                get
                {
                    return vm;
                   
                }
                set
                {
                    if(vm!=value)
                    {
                        vm = value;
                        OnPropertyChanged("Vm");
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                // the new Null-conditional Operators are thread-safe:
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    public MainPage()
            {
      this.SizeChanged += MainPage_SizeChanged;
                Vm =(Class1) DataContext;
    }
     private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                Vm.ScreenWidth =(int) Window.Current.Bounds.Width;
                Debug.WriteLine(Vm.ScreenWidth);
            }
