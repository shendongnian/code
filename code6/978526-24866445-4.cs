    Declare a global List like this,  
     List<URLData> urls = new List<URLData>();
    public class URLData
            {
                public string URL { get; set; }
                public string timestamp { get; set; }
            }
    private void getHistory(string url, string timestamp)
        {
          
            URLData urlObj = new urlObj ();
            urlObj.url = url;
            urlObj.timestamp = timestamp; 
            urls.Add(url);
        }
