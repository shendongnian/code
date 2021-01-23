    var centralServer = "10.20.30.100";
    var servers = "11.12.13.201,11.12.13.202,11.12.13.203";
    foreach (var server in servers.Split(','))
    {
        TcpClient tc = null;
        try
        {
            tc = new TcpClient(server, 25);
            tc.Client.Send(System.Text.Encoding.ASCII.GetBytes("telnet " + centralServer + " 25"));
            // tc.Client.Receive
        }
        catch (SocketException se)
        {
            // telnet failed on 'server'
        }
        finally
        {
            if (tc != null)
            {
                tc.Close();
            }
        }
    }
