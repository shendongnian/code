    using System.Net.NetworkInformation;
    var ping = new Ping();
    var reply = ping.Send("SqlServerIP");
    if (reply.Status == IPStatus.Success)
    {
        //server is available
    }
    else
    {
        //server is down
    }
