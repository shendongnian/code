      private void GetYoutubeChannel(string feedXML)
        {
            try
            {
                SyndicationFeed feed = new SyndicationFeed();
                feed.Load(feedXML);
                List<YoutubeVideo> videosList = new List<YoutubeVideo>();
                YoutubeVideo video;
                foreach (SyndicationItem item in feed.Items)
                {
                    video = new YoutubeVideo();
                    video.YoutubeLink = item.Links[0].Uri;
                    string a = video.YoutubeLink.ToString().Remove(0, 31);
                    video.Id = a.Substring(0, 11);
                    video.Title = item.Title.Text;
                    video.PubDate = item.PublishedDate.DateTime;
                    video.Thumbnail = YouTube.GetThumbnailUri(video.Id, YouTubeThumbnailSize.Large);
                    videosList.Add(video);
                }
                MainListBox.ItemsSource = videosList;
            }
            catch { }
        }
