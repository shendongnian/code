    using (var webResponse = (HttpWebResponse)WebRequest.Create("https://en.wikipedia.org/w/api.php?action=query&list=geosearch&gsradius=10000&gspage=Berlin&gslimit=500&gsprop=type&format=xml").GetResponse())
    {
        using (var reader = new StreamReader(webResponse.GetResponseStream()))
        {
            var response = XElement.Parse(reader.ReadToEnd());
            var obj = response.Descendants("gs")
                .Where(a => a.Attribute("type") != null && a.Attribute("type").Value == "landmark")
                .Select(a => a.Attribute("title").Value).ToList();
        }
    }
