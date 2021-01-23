     private List<string> GetFilePathsAndUpdateIndexHtml(string bodyFolderChoices, string containerName)
        {
            // get path to each item
            var filePaths =
                Directory.GetFiles(
                    Server.MapPath(ConfigurationManager.AppSettings["ResearchArticleFTPUploadRoot"] + "/" +
                                   bodyFolderChoices));
            // get root from web.config
            var azureRootUrl = ConfigurationManager.AppSettings["AzureBlobRootUrl"] + containerName + "/";
            // find index.html and replace relative references
            foreach (var s in filePaths)
            {
                if (s.Contains("index.html"))
                {
                    var doc = new HtmlDocument();
                    doc.LoadHtml(System.IO.File.ReadAllText(s));
                    HtmlNodeCollection links = doc.DocumentNode.SelectNodes("//*[@background or @lowsrc or @src or @href]");
                    if (links == null)
                        continue;
                    foreach (HtmlNode link in links)
                    {
                        // references to outside URLs this will break unless we check for 'http' and leave alone
                        if (link.Attributes["background"] != null && !link.Attributes["background"].Value.Contains("http"))
                            link.Attributes["background"].Value = azureRootUrl + link.Attributes["background"].Value;
                        if (link.Attributes["href"] != null && !link.Attributes["href"].Value.Contains("http"))
                            link.Attributes["href"].Value = azureRootUrl + link.Attributes["href"].Value;
                        if (link.Attributes["lowsrc"] != null && !link.Attributes["lowsrc"].Value.Contains("http"))
                            link.Attributes["lowsrc"].Value = azureRootUrl + link.Attributes["lowsrc"].Value;
                        if (link.Attributes["src"] != null && !link.Attributes["src"].Value.Contains("http"))
                            link.Attributes["src"].Value = azureRootUrl + link.Attributes["src"].Value;
                    }
                    doc.Save(s);
                }
            }
            return filePaths.ToList();
        }
