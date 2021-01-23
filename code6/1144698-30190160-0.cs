        void ProcessPage(string response, bool secondPass, Job j)
        {
            using (var wc = new WebClient())
            {
                LinkItem[] linkResponse = LinkFinder.Find(response).ToArray();
        
                foreach (LinkItem i in linkResponse)
                {
                    if (secondPass)
                    {
                        if (string.IsNullOrEmpty(i.Href))
                            continue;
                        else if (i.Href.Contains("http://loreipsum."))
                        {
                            if (DownloadImage(i.Href, ID(i.Href)))
                                j.Downloaded++;
                        }
                    }
                    else
                    {
                        if (i.Href.Contains(";id="))
                        {
                            var alterResponse = wc.DownloadString("http://www." + j.Provider.ToString() + "/index.php?page=post&s=view&id=" + ID(i.Href));
                            ProcessPage(alterResponse, true, j);
                        }
                    }
                }
            }
        }
