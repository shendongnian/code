    var handler = new ConsoleEventDelegate(ConsoleEventCallback);
                 SetConsoleCtrlHandler(handler, true);
    static bool ConsoleEventCallback(int eventType)
    {
        if (eventType == 2)
        {
            //Main thread Console is being closed!
           // handle other threads
        }
        Thread.Sleep(5000);
        return false;
    }
