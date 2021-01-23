    public string Type
    {
      get{...}
      set
      {
        RaisePropertyChanged(); //will notify when "Type" changes
        RaisePropertyChanged("isTypeB"); //will notify that isTypeB is changed
      }
    }
    ...
    public bool isTypeB => Type == "TypeB";
