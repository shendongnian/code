    try
    {
        IPHostEntry GetIPHost = null;
        var action = new Action(() => GetIPHost = Dns.GetHostByName(Request.QueryString["domain"] + ".org"));
        action.WaitForExit(1000); // this will cancel the method after 1000 milliseconds
        if (GetIPHost != null)
        {
            LblValue.Text += "<br>" + Request.QueryString["domain"] + ".org#";
            foreach (IPAddress ip in GetIPHost.AddressList)
            {
                long HostIpaddress = ip.Address;
                LblValue.Text += ip.ToString() + "#";
            }
        }
    }
    catch (Exception ex)
    {
        LblValue.Text += "<br>" + Request.QueryString["domain"] + ".org#";
        LblValue.Text += "" + ex.Message + "#";
    }
The WaitForExit extension method:
