        static IEnumerable<TcpConnection> GetProcessConnection(IPEndPoint ep)
        {
            var p = Process.GetCurrentProcess();
            return TcpConnection.GetAll().Where(c => ep.Equals(c.RemoteEndPoint) && c.ProcessId == p.Id);
        }
        
        HttpWebRequest req = ...
        // this is how you can get the enpoint, or you can also built it by yourself manually
        IPEndPoint remoteEndPoint;
        req.ServicePoint.BindIPEndPointDelegate += (sp, rp, rc) =>
            {
                remoteEndPoint = rp;
                return null;
            };
        // TODO: here, you need to connect, so the connection exists
        var cnx = GetProcessConnection(remoteEndPoint).FirstOrDefault();
        
        // access denied here means you don't have sufficient rights
        cnx.DataStatsEnabled = true;
        
        // TODO: here, you need to do another request, so the values are incremented
        // now, you should get non-zero values here
        // note TcpConnection also has int/out bandwidth usage, and in/out packet usage.
        Console.WriteLine("DataBytesIn:" + cnx.DataBytesIn);
        Console.WriteLine("DataBytesOut:" + cnx.DataBytesOut);
        
        // if you need all connections in the current process, just do this
        ulong totalBytesIn = 0;
        ulong totalBytesOut = 0;
        Process p = Process.GetCurrentProcess();
        foreach (var cnx in TcpConnection.GetAll().Where(c => c.ProcessId == p.Id))
        {
            totalBytesIn += cnx.DataBytesIn;
            totalBytesOut += cnx.DataBytesOut;
        }
