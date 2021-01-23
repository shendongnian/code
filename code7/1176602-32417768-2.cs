    public static class TabletPCSupport
    {
	   private static readonly int SM_CONVERTIBLESLATEMODE = 0x2003;
	   private static readonly int SM_TABLETPC = 0x56;
	
	   private static Boolean isTabletPC = false;
	
	   public static Boolean SupportsTabletMode { get { return isTabletPC; }}
	
	   public static Boolean IsTabletMode 
	   {
		   get
		   {
			   return QueryTabletMode();
		   }
	   }
	
	   static TabletPCSupport ()
	   {
	    	isTabletPC = (GetSystemMetrics(SM_TABLETPC) != 0);
	   }
	
	   [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto, EntryPoint = "GetSystemMetrics")]
	   private static extern int GetSystemMetrics (int nIndex);
	
	   private static Boolean QueryTabletMode ()
	   {
		   int state = GetSystemMetrics(SM_CONVERTIBLESLATEMODE);
		   return (state == 0) && isTabletPC;
	   }
    }
