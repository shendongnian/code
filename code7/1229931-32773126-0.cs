    private string _inputString;
    public string InputString {
      get { return _inputString; }
      set {
        _inputString = value;
        RaisePropertyChanged("InputString");
        RaisePropertyChanged("IsValidLength");
      }
    }
    public bool IsValidLength {
      get { return string.IsNullOrEmpty(InputString) || InputString.Length <= MAX_LENGTH; }
    }
