    using (var ctx = new ClientContext(webUri))
    {
        var pageFile = ctx.Web.GetFileByServerRelativeUrl(pageUrl);
        var pageItem = pageFile.ListItemAllFields;
        pageItem["PublishingPageImage"] = "<img src='/PublishingImages/PageLogo.png'>";
        pageItem.Update();
        ctx.ExecuteQuery();
    }
