    void Main()
    {
        Console.WriteLine("Starting request at " + DateTime.Now);
        WebClient client = new WebClient();
        try
        {
            string response = client.DownloadString("http://slowsite.local/");
            Console.WriteLine("Response returned at " + DateTime.Now);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.GetType() + " " + ex.Message + " at " + DateTime.Now);
        }
    }
