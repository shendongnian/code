     public override void Process(HttpRequestArgs args)
     {
            Assert.ArgumentNotNull(args, "args");
            HttpContext currentContext = HttpContext.Current;
            string sRequestedURL = currentContext.Request.Url.ToString().ToLower();
            if (!sRequestedURL.EndsWith("sitemap.ashx"))
                return;
            if (((Context.Item != null && Context.Item.Name == "*") && (Context.Database != null)) && (args.Url.ItemPath.Length != 0))
            {
                return;
            }
            // uses get descendants which isn't very good for performance!! Might want to change this part
            Item[] items = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath).Axes.GetDescendants();
            if (items.Length > 0)
            {
                string priority = "1.0";     
                // class used to create xml nodes          
                SiteMapFeedGenerator feedGenerator = new SiteMapFeedGenerator(currentContext.Response.Output);
                feedGenerator.WriteStartDocument();
                foreach (Item node in items)
                {
                    if (!String.IsNullOrEmpty(node["Sitemap Display"]) && node["Sitemap Display"] == "1")
                    {
                        feedGenerator.WriteItem("http://" +currentContext.Request.Url.Host  + LinkManager.GetItemUrl(node), DateTime.Now, priority);
                    }
                }
                feedGenerator.WriteEndDocument();
                feedGenerator.Close();
                currentContext.Response.ContentType = "text/xml";
                currentContext.Response.Flush();
                currentContext.Response.End();
            }
        }
       
