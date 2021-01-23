    internal class MyClass
    {
      //use this flag to maximize process window.
      const int SW_SHOWMAXIMIZED = 3;
      //use this flag to open process window normally.
      const int SW_SHOWNORMAL = 1;
      [DllImport("user32.dll")]
      static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
      public static void Main(string[] args)
      {
        var processName = "notepad";
        var process = Process.GetProcessesByName(processName).FirstOrDefault();
        if (process != null)
          ShowWindow(process.MainWindowHandle, SW_SHOWNORMAL);
        else
          Process.Start(processName);
      }
    }
