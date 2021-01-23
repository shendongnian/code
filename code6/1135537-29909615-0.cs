      [STAThread]
      static void Main(
      {
    
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        do{
          var page = new ConnectPage();
          Application.Run(page);
        } while (page.SomePropertyOrMethodToKeepAnOptionToRestart);
    }
