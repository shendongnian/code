        static IEnumerable<TcpConnection> GetProcessConnection(IPEndPoint ep)
        {
            var p = Process.GetCurrentProcess();
            return TcpConnection.GetAll().Where(c => ep.Equals(c.RemoteEndPoint) && c.ProcessId == p.Id);
        }
        
        HttpWebRequest req = ...
        // TODO: here, you need to connect, so the connection exists
        var cnx = GetProcessConnection(rp).FirstOrDefault();
        
        // access denied here means you don't have sufficient rights
        cnx.DataStatsEnabled = true;
        
        // TODO: here, you need to do another request, so the values are incremented
        // now, you should get non-zero values here
        // note TcpConnection also has int/out bandwidth usage, and in/out packet usage.
        Console.WriteLine("DataBytesIn:" + cnx.DataBytesIn);
        Console.WriteLine("DataBytesOut:" + cnx.DataBytesOut);
        
        
