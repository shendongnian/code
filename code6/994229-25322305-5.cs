    internal static class NativeMethods
    {
        public const int SC_CLOSE     = 0xF060;
        public const int MF_BYCOMMAND = 0;
        public const int MF_ENABLED   = 0;
        public const int MF_GRAYED    = 1;
    
        [DllImport("user32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool revert);
        
        [DllImport("user32.dll")]
        public static extern int EnableMenuItem(IntPtr hMenu, int IDEnableItem, int enable);
    }
    public class MyForm : Form
    {
    
        // ...
    
        // If "enable" is true, the close button will be enabled (the default state).
        // If "enable" is false, the Close button will be disabled.
        bool SetCloseButton(bool enable)
        {
            IntPtr hMenu = NativeMethods.GetSystemMenu(this.Handle, false);
            if (hMenu != IntPtr.Zero)
            {
                NativeMethods.EnableMenuItem(hMenu,
                                             NativeMethods.SC_CLOSE,
                                             NativeMethods.MF_BYCOMMAND | (enable ? NativeMethods.MF_ENABLED : NativeMethods.MF_GRAYED));                                
            }
        }   
    }
    
