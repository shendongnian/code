    private string _specialString;
    
    public string SpecialString
    {
      get
      {
        return _specialString;
      }
      set
      {
        if (_specialString != value)
        {
          _specialString = value;
          OnValueChanged();
        }
      }
    }
