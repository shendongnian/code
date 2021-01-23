    [DllImport("user32.dll")]
    public static extern int FindWindow(string lpClassName, string lpWindowName);
    
    [DllImport("user32.dll")]
    private static extern int ShowWindow(int hwnd, int nCmdShow);
    
    const int SW_HIDE = 0;
    
    public void hideScannerDialog()
            {
                // retrieve the handler of the window  
                int iHandle = FindWindow("AV_PropertyDlg", "Scanner Properties"); //The className & WindowName I got using Spy++
                if (iHandle > 0)
                {
                    // Hide the window using API        
                    ShowWindow(iHandle, SW_HIDE);
                }
            }
