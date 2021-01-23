    SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
            {
                if(e.Reason==SessionSwitchReason.SessionLogon)
                {
    
                }
            }
