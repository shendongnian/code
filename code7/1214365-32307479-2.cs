    class LabelViewModel:INPC
    {
     public event PropertyChangedEventHandler PropertyChanged=new delegate{};
     bool _isBlueColor;
     public bool IsBlueColor
     {
      get
      {
        return _isBlueColor;
      }
      set
      {
        _isBlueColor=value;
        OnPropertyChange();
      }
    }
    public OnPropertyChange([CallerMemberName] string propname="")
    {
      PropertyChanged.Invoke(this,ew PropertyChangedEventArgs(propname));
    }
 
    }
