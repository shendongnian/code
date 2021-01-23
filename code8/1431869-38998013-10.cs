    private void PopulateLatestServer()
    {
        try
        {
            string SERVER_ID = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\PODIA", "LATESTSERVER", null).ToString();
            BDO_SERVERS latestserver = SavedServers.Where(a => a.Server_ID == SERVER_ID).FirstOrDefault();
            setServerURL(latestserver.ServerURL, false);
            Username = latestserver.Username;
            OnPasswordSet(latestserver.Password);
        }
        catch (Exception)
        {
            Global.WriteLog("Could not find last logged in server.", EventLogEntryType.Warning);
        } 
    }
