            public Dictionary<string, string> GetImage(string name)
            {
                string result1;
                string result2;
                using (WebClient client = new WebClient())
                {
                        var uri = "https://en.wikipedia.org/w/api.php?action=query&format=json&prop=pageimages&pithumbsize=400&titles="+name;
                        string requestUrl = string.Format(uri, name);
                        var response = client.DownloadString(new Uri(uri));
                        var responseJson = JsonConvert.DeserializeObject<ImgRootobject>(response);
                        var firstKey = responseJson.query.pages.First().Key;
                        result1 = responseJson.query.pages[firstKey].thumbnail.source;
                        result2 = responseJson.query.pages[firstKey].title;
                        var hash = uri.GetHashCode();
                }
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary.Add("Source", result1);
                dictionary.Add("Title", result2);
                return dictionary;
            }
