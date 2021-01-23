    private bool _isOpen;
    public bool IsOpen
    {
      get { return _isOpen; }
      set
      {
        if (_isOpen == value) return;
        _isOpen = value;
        RaisePropertyChanged("IsOpen");
      }
    }
