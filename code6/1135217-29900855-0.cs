    public class News
    {
        public string author { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string contentSnippet { get; set; }
        public string link { get; set; }
        public string publishedDate { get; set; }
        public string[] getFeed(string Website)
        {
            string path = @"http://ajax.googleapis.com/ajax/services/feed/load?v=1.0&q=" + Website;
            string json = new WebClient().DownloadString(path);
            JObject jsonObject = JObject.Parse(json);
            JArray array = (JArray) jsonObject["responseData"]["feed"]["entries"];
            var content = array.Select(token => JsonConvert.DeserializeObject<News>(token.ToString())).ToArray();
            foreach(News data in content)
            {
                return new string[] { data.title, data.link };
            }
            return new string[] { "" };
        }
    }
