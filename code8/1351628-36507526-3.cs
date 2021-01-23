    private int CurrentMonth {
                get {
                    var monthfromSession = HttpContext.Current.Session["ClassNameSpace.CurrentMonth"];
                    return monthfromSession!= null ? (int)monthfromSession : 0;
                }
                    set {
                    HttpContext.Current.Session["ClassNameSpace.CurrentMonth"] = value;
                 }
            }
    public void Calc_Rotation()
    {
    
        switch (this.CurrentMonth)  // it should have correct month value now.
        {
            case 1:
                rotation_month = "A";
                break;
            case 2:
                rotation_month = "B";
                break;
            case 3:
           ....
        }
    }
