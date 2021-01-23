    private static System.Timers.Timer timer;
    public static void Main()
    {
        timer = new System.Timers.Timer(10000);
        timer.Elapsed += new ElapsedEventHandler(saveUsers);
        timer.Interval = 3600000;
        timer.Enabled = true;
    }
     public static void saveUsers(object source, ElapsedEventArgs e)
        {
            string  uri = "https://****dd.harvestapp.com/people";
            using (WebClient webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                webClient.Headers[HttpRequestHeader.Accept] = "application/json";
                webClient.Headers[HttpRequestHeader.Authorization] = "Basic " + Convert.ToBase64String(new UTF8Encoding().GetBytes(usernamePassword));
    
                string response = webClient.DownloadString(uri);
    
    
                File.WriteAllText(jsonPath, response);
    
            }
    
        }
