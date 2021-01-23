    private async void BindFeeds(string URL)
            {
                progressRing.IsActive = true;
                
                var uri = new Uri(URL);
                var httpClient = new HttpClient();
    
                // Always catch network exceptions for async methods
                httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                var result = await httpClient.GetAsync(uri);
    
                var xmlStream = await result.Content.ReadAsStreamAsync();
                XDocument loadedData = XDocument.Load(xmlStream);
    
                foreach (var data in loadedData.Descendants("Table"))
                {
                       
    
                    try
                    {
                        oc.Add(new Feeds
                        {
                            BlogId = data.Element("Blogs_CID").Value.ToString(),
                            Description = data.Element("Blogs_BriefDescription").Value.ToString(),
                            IconImage = videoIcon,
                            Heading = data.Element("Blogs_Heading").Value.ToString().Trim(),
                            MainImage = feedImageThumbnail, //data.Element("Blogs_SquareImagePath").Value.ToString(),
                            TimeStamp = data.Element("TimeElapsed").Value.ToString(),
                            SourceURL = data.Element("Blogs_SourceURL").Value.ToString()
                        });
                        
                    }
                    catch (Exception)
                    {
                        //throw;
                    }               
                }
                httpClient.Dispose();
      
                if (lstLatest.Items.Count == 0)
                {
                    lstLatest.ItemsSource = oc;
                }
                else
                {
                    NotifyPropertyChanged();
                }
    
                httpClient.Dispose();
                progressRing.IsActive = false;
            }
