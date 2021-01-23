      private string _myAppName;
      public string MyAppName
      {
        get{return _myAppName;}
        set{_appName = value; RaisePropertyChanged("MyAppName");}
      }
