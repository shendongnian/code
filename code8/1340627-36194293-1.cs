    public void OnSessionChange(SessionChangeDescription changeDescription)
    {
        switch (changeDescription.Reason)
        {
            //Case of Logon
            case SessionChangeReason.SessionLogon:
                //CreateRunningProcessesLog("UserSession-SessionLogon");
    
                UserSession userSessionLogin = new UserSession()
                {
                    UserName = MachineHelper.GetUsername(),
                    UserGuid = MachineHelper.GetUserGuid(),
                    MachineGuid = MachineHelper.GetMachineGUID(),
                    LoginTime = DateTime.Now.ToUniversalTime(),
                    SessionGuid = Guid.NewGuid(), //New Guid generated for tracking the UserSession, this will be created on on logon
                    IsReadable = false,
                    SessionId = changeDescription.SessionId,
                };
    
                UserSessionInfo userSessionInfoLogin = new UserSessionInfo()
                {
                    UserName = MachineHelper.GetUsername(),
                    SessionGuid = userSessionLogin.SessionGuid,
                    IsActiveUser = true,
                    SessionId = changeDescription.SessionId,
                    LoginTime = userSessionLogin.LoginTime,
                    State = RowState.Added,
                };  
    
                var userSessionLookupTable = LoadUserSessionData();
                userSessionLookupTable.Add(userSessionInfoLogin.SessionId, userSessionInfoLogin);
                SaveUserSessionData(userSessionLookupTable);
                break;
    
            //Case of Logoff
            case SessionChangeReason.SessionLogoff:
                UserSession userSessionLogoff = new UserSession()
                {
                    UserName = MachineHelper.GetUsername(),
                    UserGuid = MachineHelper.GetUserGuid(),
                    MachineGuid = MachineHelper.GetMachineGUID(),
                    LogOffTime = DateTime.Now.ToUniversalTime(),
                    IsReadable = true,
                    SessionId = changeDescription.SessionId,
                };
    
                var userSessionLookupTable = LoadUserSessionData();
                userSessionLookupTable.Remove(userSessionLogoff.SessionId);
                SaveUserSessionData(userSessionLookupTable);
                break;
        }
    }
