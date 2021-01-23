    Attachmate.Reflection.Framework.Application reflectionApplication = null;
    reflectionApplication = MyReflection.CreateApplication("myWorkspace", true);
    if (reflectionApplication != null)
    {
        IIbmTerminal terminal = (IIbmTerminal)reflectionApplication.CreateControl(
            @"C:\ProgramData\Attachmate\Reflection\<your session file>.rd3x");
        if (terminal != null)
        {
            terminal.Connect();
            //You can also use AfterConnect event to wait for the connection.
            while (!terminal.IsConnected)
            {
                System.Threading.Thread.Sleep(500);
            }
            IView sessionView;
            IFrame theFrame = (IFrame)reflectionApplication.GetObject("Frame");
            sessionView = theFrame.CreateView(terminal);
            IIbmScreen screen = terminal.Screen;
            screen.WaitForHostSettle(6000, 3000);
        }
        else
            Console.WriteLine("Can not create the control.");
    }
    else
        Console.WriteLine("Failed to get Application object.");
