    [DllImport ("User32.dll")]
    static extern int SetForegroundWindow(IntPtr hwnd);
     
    public static void PasteToApplication(string appName)
    {
      var proc = Process.GetProcessesByName(appName).FirstOrDefault();
      if(proc != null)
      {
        var handle = proc.MainWindowHandle;
        SetForegroundWindow(handle);
        SendKeys.SendWait("^v");
      }
    }
