    string url = @"https://en.wikipedia.org/w/api.php?action=query&prop=imageinfo&format=json&iiprop=url&iiurlwidth=400&titles=File%3ALuftbild%20Flensburg%20Schleswig-Holstein%20Zentrum%20Stadthafen%20Foto%202012%20Wolfgang%20Pehlemann%20Steinberg-Ostsee%20IMG%206187.jpg|File%3AHafen%20St%20Marien%20Flensburg2007.jpg|File%3ANordertor%20im%20Schnee%20%28Flensburg%2C%20Januar%202014%29.JPG";
    // i'll leave it up to you to do any null and error checking
    using (var client = new WebClient())
    {
        var text = client.DownloadString(url);
        var result = JsonConvert.DeserializeObject<RootObject>(text);
        foreach (var page in result.Query.Pages)
        {
            foreach (var imageInfo in page.Value.ImageInfo)
            {
                Console.WriteLine("{0}: {1}", page.Value.Title, imageInfo.ThumbUrl);
            }
        }
    }
    // the relevant classes for deserialization
    public class RootObject
    {
        public string BatchComplete { get; set; }
        public Query Query { get; set; }
    }
    public class Query
    {
        // this is how you can deal with those invalid identifiers
        // the -1, -2, -3 will be placed as keys inside this dictionary
        public Dictionary<string, Page> Pages { set; get; }
    }
    public class Page
    {
        public int Ns { get; set; }
        public string Title { get; set; }
        public string Missing { get; set; }
        public string ImageRepository { get; set; }
        public List<ImageInfo> ImageInfo { get; set; }
    }
    public class ImageInfo
    {
        public string ThumbUrl { get; set; }
        public int ThumbWidth { get; set; }
        public int ThumbHeight { get; set; }
        public string Url { get; set; }
        public string DescriptionUrl { get; set; }
    }
