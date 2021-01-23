    public string Type
    {
      get{...}
      set
      {
        //...set logic
        RaisePropertyChanged(); //will notify when "Type" changes
        RaisePropertyChanged("isTypeB"); //will notify that isTypeB is changed
      }
    }
    ...
    public bool isTypeB => Type == "TypeB";
