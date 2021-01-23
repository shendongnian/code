    bool isVisible;
    public bool IsVisible
    {
      get { return isVisible;}
      set
      {
        isVisible = value;
        OnPropertyChanged("IsVisible");
      }
    }
