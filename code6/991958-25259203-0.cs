    public string Server
    {
      get { return _server; }
      set
      {
          if (value != _server)
          {
              _server = value;
              RaisePropertyChanged(ref _server, value, () => Server);
              if(Computers == null) {
                Computers = new ObservableCollection<string>();
              } else {
                Computers.Clear();
              }
              Computers.AddRange(GetComputers());
          }
      }
    }
