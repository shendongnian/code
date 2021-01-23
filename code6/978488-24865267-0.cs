    var handler = new ConsoleEventDelegate(ConsoleEventCallback);
                 SetConsoleCtrlHandler(handler, true);
    static bool ConsoleEventCallback(int eventType)
    {
        if (eventType == 2)
        {
         //Console is being closed!
         }
              
     }
