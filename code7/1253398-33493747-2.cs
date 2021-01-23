    static void Main(string[] args)
    {
        Console.WriteLine(PingTest());
    }
    public static bool PingTest()
    {
        Ping ping = new Ping();
        PingReply pingStatus = ping.Send(IPAddress.Parse("208.69.34.231"));
        //For the web address you need !
        //PingReply pingStatus = ping.Send("www.google.com");
        return pingStatus.Status == IPStatus.Success;
       
    }
