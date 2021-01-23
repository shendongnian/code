    [DllImport("User32.dll")]
    private static extern bool GetLastInputInfo(ref LASTINPUTINFO dummy);
    
    private uint GetIdleTime()
    {
        LASTINPUTINFO lastUserAction = new LASTINPUTINFO();
        lastUserAction.CbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastUserAction);
        GetLastInputInfo(ref lastUserAction);
        return (uint)Environment.TickCount - lastUserAction.DwTime;
    }   
    internal struct LASTINPUTINFO
    {        
        public uint CbSize;   
        public uint DwTime;   
        
    }
