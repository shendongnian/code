    private static void CheckProxy(object state)
    {
        var u = user[0];
        var p = pass[0];
        var l = new List<MyIP>();
        l.Add(new MyIP { IP = "192.168.1.1" });
        l.Add(new MyIP { IP = "192.168.1.2" });
        l.Add(new MyIP { IP = "192.168.1.3" });
        Parallel.ForEach(l.ToArray(), (ip_item) =>
        {
            try
            {
                using (var client = new ProxyClient(ip_item, u, p))
                {
                    Console.WriteLine(ip_item, user, pass);
                    client.Connect();
                    item.AcceptsConnection = client.IsConnected;
                }
            }
            catch
            {
                lock(l)
                    l.Remove(item);
            }
        });
        foreach (var item in l)
        {
            if (item.AcceptsConnection == true)
            {
                WriteToFile(user[0], pass[0]);
            }
            Console.WriteLine(item.IP + " is " + (item.AcceptsConnection) + " accepts connections" + " doesn not accept connections");
        }
    }
