    public MyUserControlViewModel(ISingletonVM singletonVM)
    {
         _singletonVM = singletonVM;
         _singletonVM.PropertyChanged += (sender, args) => OnPropertyChanged("TestChecked");
    }
