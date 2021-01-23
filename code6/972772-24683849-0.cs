    [DllImport("User32.dll")]
    static extern bool SetWindowPos(int hwnd, int hwndInsertAfter, int x, int y, int w, int h, uint flags);
    public const int SWP_HIDEWINDOW = 0x0080;
    
    public static void Main()
    {
        //...Setup AutoCAD...
        //Change window size and hide it before calling to open mainWin inside the DLL.
        SetWindowPos(acadApp.HWND32, 1, 0, 0, 0, 0, SWP_HIDEWINDOW);
        
        //Display mainWin by entering the DLL.
        acadApp.ActiveDocument.SendCommand("AUTOCADCOMMANDNAME");
        
        //Terminate application as before...
    }
