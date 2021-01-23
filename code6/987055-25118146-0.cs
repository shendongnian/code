    using System.Net
    private bool IsOnline() 
    {
        try
        {
            IPHostEntry iPHostEntry = Dns.GetHostEntry("www.wikipedia.com");
            return true;
        }
        catch (SocketException ex) 
        {
            return false;
        }
    }
