    public ImageInfo GetImage(string name)
    {                
        ImageInfo info = new ImageInfo();
        using (WebClient client = new WebClient())
        {
            var uri = "https://en.wikipedia.org/w/api.php?action=query&format=json&prop=pageimages&pithumbsize=400&titles="+name;
            string requestUrl = string.Format(uri, name);
            var response = client.DownloadString(new Uri(uri));
            var responseJson = JsonConvert.DeserializeObject<ImgRootobject>(response);
            var firstKey = responseJson.query.pages.First().Key;
            info.Image = responseJson.query.pages[firstKey].thumbnail.source;
            info.Title = responseJson.query.pages[firstKey].title;
            var hash = uri.GetHashCode();
        }
        return info;
    }
