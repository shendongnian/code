    [DllImport("user32.dll", SetLastError = true)]
    static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
    public void Navigate2URL(int processId, string strUrl)
    {
        SHDocVw.ShellWindows SWs = new SHDocVw.ShellWindows();
        SHDocVw.InternetExplorer IE = null;
                
        for (int i = 0; i < SWs.Count; i++)
        {
            IE = (SHDocVw.InternetExplorer)SWs.Item(i);
    
            uint pid;
            GetWindowThreadProcessId((IntPtr)IE.HWND, out pid);
            if ((IntPtr)IE.HWND == (IntPtr)pid)
            {
                object o = null;
                IE.Navigate2(strUrl, ref o, ref o, ref o, ref o);
            }
        }
    }
