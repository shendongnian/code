    var node = ((SiteMapNode)e.Item.DataItem);
    var litTitle = ((Literal)e.Item.FindControl("litTitle"));
    if (node != null)
    {
        litTitle.Text = Sitemap.ResourceManager.GetString(node.ResourceKey, CultureInfo.CurrentCulture);
    }
    
