    public class MyIP
    {
        public string IP { get; set; }
        public bool IsConnected { get; set; }
    }
---
    var l = new List<MyIP>();
    // create a copy of `l`, so i can delete items
    Parallel.ForEach(l.ToArray(), (item) =>
    {
        try
        {
            using (var client = new ProxyClient(item.IP, user, pass))
            {
                Console.WriteLine(item.IP, user, pass);
                client.Connect();
                if (client.IsConnected)
                {
                    item.IsConnected = true;
                    return;
                }
                else
                {
                    item.IsConnected = false;
                    client.Disconnect();
                }
            }
        }
        catch
        {
            l.Remove(item);
        }
    });
    foreach(var item in l)
    {
        Console.WriteLine(item.IP + " is " + (item.IsConnected) ? " connected" : " not connected");
    }
