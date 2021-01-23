    // in your item class
    private SolidColorBrush backBrush = new SolidColorBrush(Colors.Transparent);
    public SolidColorBrush BackBrush 
    { 
       get { return backBrush; }
       set { backBrusk = value; RaiseProperty("BackBrush"); }
    }
