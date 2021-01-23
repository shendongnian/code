    while (!ips.IsEmpty)
    {
         IpAndPort ipAndPort;
         if (!ips.TryTake(out ipAndPort)) continue;
         try
         {
               //code here to send message using below IP and Port
               var ip = ipAndPort.IpAddress;
               var port = ipAndPort.Port;
               /----
               oServer.SocksProxyServer = ip;
               oServer.SocksProxyPort = port;
         }
         catch (Exception ex)
         {
               Console.WriteLine(ex.Message);
         }
    }
