    var centralServer = "10.20.30.100";
    var centralPort = 25;   // 25 as per OP
    var servers = "11.12.13.201,11.12.13.202,11.12.13.203";
    var telnetPort = 23;
    foreach (var server in servers.Split(','))
    {
        TcpClient tc = null;
        try
        {
            tc = new TcpClient(server, telnetPort);
            tc.Client.Send(System.Text.Encoding.ASCII.GetBytes("telnet " + centralServer + " " + centralPort));
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
