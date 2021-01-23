    public bool IsFoo
    {
       get { return _IsFoo; }
       set
       {
          _isFoo = value;
          OnPropertyChanged("IsFoo");
       }
    }
