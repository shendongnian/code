    public override List<SitemapUrl> GetUrls(int portalId, PortalSettings ps, string version)
            {
                var listOfUrls = new List<SitemapUrl>();
    
                foreach (Article ai in ArticleController.GetAllArticles(portalId))
                {
    
                    var pageUrl = new SitemapUrl
                                  {
                                      Url =
                                          ArticleController.GetArticleLink(ai.TabID, ai.ArticleId),
                                      Priority = (float)0.5,
                                      LastModified = ai.LastModifiedOnDate,
                                      ChangeFrequency = SitemapChangeFrequency.Daily
                                  };
                    listOfUrls.Add(pageUrl);
    
                }
                return listOfUrls;
            }
        }
