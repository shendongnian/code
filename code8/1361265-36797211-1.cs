    [STAThread]
    static void Main()
    {
      string[] args = Environment.GetCommandLineArgs();
      var singleApp = new SingleAppInstance();
      singleApp.Run(args);
    }
