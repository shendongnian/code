    public class URLData
            {
                public string URL { get; set; }
                public string timestamp { get; set; }
            }
    private void getHistory(string url, string timestamp)
        {
            List<URLData> urls = new List<URLData>();
            URLData urlObj = new urlObj ();
            urlObj.url = url;
            urlObj.timestamp = timestamp; 
            urls.Add(url);
        }
