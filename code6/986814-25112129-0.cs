    public ICommand LoginCommand
    {
       get
       {
          return new RelayCommand(() =>
          {
             ButtonText = "New Text";
             DoSomething();
          });
       }
    }
    private string _buttonText;
    public string ButtonText
    {
       get { return _buttonText; }
       set
       {
          if (value.Equals(_buttonText))
             return;
          _buttonText = value;
          RaisePropertyChanged("ButtonText");
       }
    }
