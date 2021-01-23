    private void ReadRss()
        {
            string RssFeedUrl = "http://feeds.feedburner.com/neowin-main";
            List<Feeds> feeds = new List<Feeds>();
            try
            {
                //XDocument xDoc = new XDocument();
                //xDoc = xDocument.Load(RssFeedUrl);
                XDocument xDoc = XDocument.Load(RssFeedUrl);
                var items = (from x in xDoc.Descendants("item")
                             select new
                             {
                                 title = x.Element("title").Value,
                                 link = x.Element("link").Value,
                                 pubDate = x.Element("pubDate").Value,
                                 description = x.Element("description").Value,
                             });
                if (items != null)
                {
                    foreach (var i in items)
                    {
                        Feeds f = new Feeds
                        {
                            Title = i.title,
                            Link = i.link,
                            PublishDate = i.pubDate,
                            Description = i.description,
                        };
                        feeds.Add(f);
                    }
                }
                gridViewRSS.DataSource = feeds;
                gridViewRSS.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
