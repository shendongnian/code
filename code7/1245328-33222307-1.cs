    static void Main(string[] args)
    {
        // Dictionary to keep the sites list and the list of replies for each site
        Dictionary<string, List<PingReply>> lstWebSites = new Dictionary<string, List<PingReply>>();
        lstWebSites.Add("www.yahoo.com", new List<PingReply>());
        lstWebSites.Add("www.att.com", new List<PingReply>());
        lstWebSites.Add("www.verizon.com", new List<PingReply>());
        string filename = @"d:\temp\PingLog.csv";
        // Start your loops
        for (int i = 0; i < 4; i++)
            foreach (string website in lstWebSites.Keys)
            {
                try
                {
                    Ping myPing = new Ping();
                    PingReply reply = myPing.Send(website, 1000);
                    if (reply != null)
                    {
                        // Do not write to file here, just add the 
                        // the reply to your dictionary using the site key
                        lstWebSites[website].Add(reply);
                    }
                }
                catch
                {
                    Console.WriteLine("ERROR: You have some TIMEOUT issue");
                }
            }
        using (var writer = new StreamWriter(filename, false))
        {
            // For each site, extract the RoundtripTime and 
            // use string.Join to create a comma separated line to write
            foreach(string website in lstWebSites.Keys)
                writer.WriteLine(website + " , " + 
                    string.Join(",", lstWebSites[website]
                          .Select(x => x.RoundtripTime)
                          .ToArray()));
        }
        
        string fileText = File.ReadAllText(filename);
        Console.WriteLine(fileText);
    }
