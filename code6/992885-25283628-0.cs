    [DllImport ("user32.dll")]
    private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
    private const int SW_MAXIMISE = 3;
    public void OpenWindow()
    {
           SHDocVw.InternetExplorer ie = new SHDocVw.InternetExplorerClass();  //Instanciate the class.
            ShowWindow((IntPtr)ie.HWND, SW_MAXIMISE);   //Maximise the window.
            ie.Visible = true;   //Set the window to visible.
    }
