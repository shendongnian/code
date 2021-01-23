    public Boolean IsConnected()
    {
        Boolean retVal = false;
        using (PowerShell ps = PowerShell.Create())
        {
            ps.AddCommand("Get-VpnS2SInterface");
            ps.AddParameter("Name", "VpnAtlanta02");
            foreach (PSObject result in ps.Invoke())
            {
                retVal = ("" + result.Members["ConnectionState"].Value).ToLower() == "connected";
            }
        }
        return retVal;
    }
    public void Connect()
    {
        using (PowerShell ps = PowerShell.Create())
        {
            ps.AddCommand("Connect-VpnS2SInterface");
            ps.AddParameter("Name", "VpnAtlanta02");
            ps.AddParameter("PassThru");
           foreach (PSObject result in ps.Invoke())
           {
               String destination = "";
               foreach (String s in result.Members["Destination"].Value as String[])
               {
                   destination += "{" + s + "}";
               }
               Service1.InfoLog("Destination=" + destination + "\r\n" +
                "ConnectionState=" + result.Members["ConnectionState"].Value + "\r\n");
            }
        }
    }
    public void Disconnect()
    {
        using (PowerShell ps = PowerShell.Create())
        {
            ps.AddCommand("Disconnect-VpnS2SInterface");
            ps.AddParameter("Name", "VpnAtlanta02");
            ps.AddParameter("Force");
            ps.Invoke();
            Service1.InfoLog("Nic: " + "VpnAtlanta02" + " is connected: " + IsConnected());
        }
    }
