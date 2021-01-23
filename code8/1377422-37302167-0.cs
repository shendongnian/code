    private  void   GetRSS(string rssUrl)
            {
                Task.Factory.StartNew(() => {
                    using (XmlReader r = XmlReader.Create(rssUrl))
                    {
                        SyndicationFeed feed = SyndicationFeed.Load(r);
                        Action bindData = () => {
                            lstFeedItems.ItemsSource = feed.Items;
                        };
                        this.Dispatcher.InvokeAsync(bindData);
                    }
                });
            }
