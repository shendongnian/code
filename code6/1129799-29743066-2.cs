    private static object syncObject = new object();
    
    private static DateTime currentDate;
    public static DateTime CurrentDate
    {
      get { lock (syncObject) return currentDate; }
      set { lock (syncObject) currentDate = value; }
    }
