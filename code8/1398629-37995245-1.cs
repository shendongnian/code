    List<Feed> feeds = new List<Feed>();
            Feed feed1 = new Feed();
            feed1.Title = "A Title";
            feed1.SectionName = "Section name";
            Feed feed2 = new Feed();
            feed2.Title = "Another title";
            feed2.SectionName = "Another section name";
            feeds.Add(feed1);
            feeds.Add(feed2);
            //Serialize to Xml string
            Serializer serializer = new Serializer();
            string Xml = serializer.Serialize(feeds);
            //Save to local storage
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["Feeds"] = Xml;
