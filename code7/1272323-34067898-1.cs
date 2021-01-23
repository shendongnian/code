    private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
            {
                // Put your own handler here
                switch (ctrlType)
                {
                    case CtrlTypes.CTRL_C_EVENT:
                        isclosing = true;
                        Console.WriteLine("CTRL+C received!");
                        break;
    
                    case CtrlTypes.CTRL_BREAK_EVENT:
                        isclosing = true;
                        Console.WriteLine("CTRL+BREAK received!");
                        break;
    
                    case CtrlTypes.CTRL_CLOSE_EVENT:
                        isclosing = true;
                        Console.WriteLine("Program being closed!");
                        break;
    
                    case CtrlTypes.CTRL_LOGOFF_EVENT:
                    case CtrlTypes.CTRL_SHUTDOWN_EVENT:
                        isclosing = true;
                        Console.WriteLine("User is logging off!");
                        break;
    
                }
                return true;
            }
