    public void CCleanerSample()
    {        
        var application = Application.AttachOrLaunch(new ProcessStartInfo(@"C:\Program Files\CCleaner\CCleaner.exe"));
        AutomationElement ccleanerAutomationElement = null;
        Console.Write("Waiting till WIN32 app is launching");
        while (ccleanerAutomationElement == null)
        {
            ccleanerAutomationElement = AutomationElement.RootElement.FindFirst(TreeScope.Children,
                new PropertyCondition(AutomationElement.NameProperty, "Piriform CCleaner"));
            Thread.Sleep(1000);
            Console.Write(".");
        }
        Console.WriteLine(" Done");
        var mainWindow = new Win32Window(ccleanerAutomationElement, WindowFactory.Desktop, InitializeOption.NoCache,
            new WindowSession(application.ApplicationSession, InitializeOption.NoCache));
    }
