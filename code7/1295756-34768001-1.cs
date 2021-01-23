    public bool UseBubbleNotifications
    {
     get
     {
        return useBubbleNotifications;
     }
     set
     {
        useBubbleNotifications = value;
        Other_Static_Variable = value;
        OnPropertyChange("UseBubbleNotifications");
     }
    }
    
    public void OnPropertyChange(string inName)
    {
        if(PropertyChanged != null)
          {
             PropertyChanged(this, new PropertyChangedEventArgs("inName"));
          }
    }
