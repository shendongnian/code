    uint _val = 10;
    public uint val
    {
      get
      {
        return _val;
      }
      set
      {
        if(_val!=value)
        {
          _val = value;
          OnPropertyChanged("Value");
        }
      }
    }
