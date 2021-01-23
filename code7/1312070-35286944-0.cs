    class MyClass
    {
      const int SW_SHOWMAXIMIZED = 3;
      [DllImport("user32.dll")]
      static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
      public static void Main(string[] args)
      {
        var processName = "notepad";
        var process = Process.GetProcessesByName(processName).FirstOrDefault();
        if (process != null)
          ShowWindow(process.MainWindowHandle, SW_SHOWMAXIMIZED);
        else
          Process.Start(processName);
      }
    }
