    protected override void OnSessionChange(SessionChangeDescription changeDescription)
            {
                try
                {
                    switch (changeDescription.Reason)
                    {
                        case SessionChangeReason.SessionLogon:
                            string user = GetUsername(changeDescription.SessionId);
    
                            WriteLog("Logon - Program continue" + Environment.NewLine + 
                                "User: " + user + Environment.NewLine + "Sessionid: " + changeDescription.SessionId);
                            
                            //.....
