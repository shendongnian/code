    static void Main(string[] args)
            {
                SystemEvents.SessionEnding += SystemEvents_SessionEnding;
                SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
                Console.ReadLine();  //This is needed to keep the application running.
            }
    
            static void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
            {
                switch (e.Reason)
                {
                    case SessionSwitchReason.SessionLogon:
                        //do something
                        break;
                }
            } 
