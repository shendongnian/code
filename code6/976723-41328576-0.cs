    string rel_Path = HttpContext.Current.Server.MapPath("~");
    if (_articleOrders.Any())
            {
                foreach (ArticleOrder order in _articleOrders)
                {
                    if (!string.IsNullOrEmpty(order.ArticleImage))
                    {
                        if (File.Exists(rel_Path + "\\" + order.ArticleImage))
                        {
                            var AIpath = "file:///" + rel_Path + "\\" + order.ArticleImage;
                            articleImagesList.Add(AIpath);
                        }
                    }
                }
                CreateDatasetForImages(articleImagesList);
            }
