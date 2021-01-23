    [StructLayout(LayoutKind.Sequential)] 
    public struct Point 
    { 
       public int errsize; 
       public int statmnt; 
    } 
    [DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)]    
    public static extern Point mainfun();
    
    Point p = mainfun();
    var errsize = p.errsize;
    var statmnt = p.statmnt;
