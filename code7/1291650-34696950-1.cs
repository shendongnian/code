    public static List<string> GetJenkinsJobs()
    {
        try
        {
            string credentials = ConfigurationManager.AppSettings["jenkinsUser"] + ":" + ConfigurationManager.AppSettings["jenkinsKey"];
            string authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.Authorization] = "Basic " + authorization;
                string HtmlResult = wc.DownloadString(String.Format(ConfigurationManager.AppSettings["jenkinsJobListUrl"]));
                XDocument doc = XDocument.Parse(HtmlResult);
                return doc.Root.Elements("name").Select(element => element.Value).ToList();
            }
        }
        catch (WebException e)
        {
            Console.WriteLine("Could not retreive Jenkins job list");
            throw e;
        }
    }
