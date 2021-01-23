    Using System.Runtime.InteropServices;  
    ....
    public class NativeMethods
    {
    
        [DllImport("kernel32")]
        public static extern void Sleep(uint dwMilliseconds);
    }
