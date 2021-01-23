    [DllImport("User32.dll")]
    static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, int x, int y, int w, int h, uint flags);
    public const int SWP_HIDEWINDOW = 0x0080;
    
    public static void Main()
    {
        //...Setup AutoCAD...
        //Change window size and hide it before calling to open mainWin inside the DLL.
        SetWindowPos(new IntPtr(acadApp.HWND), new IntPtr(1), 0, 0, 0, 0, SWP_HIDEWINDOW);
        
        //Display mainWin by entering the DLL.
        acadApp.ActiveDocument.SendCommand("AUTOCADCOMMANDNAME");
        
        //Terminate application as before...
    }
