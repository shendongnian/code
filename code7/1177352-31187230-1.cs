    using (var ctx = new ClientContext(webUri))
    {
        var list = ctx.Web.Lists.GetByTitle(listTitle);
        list.CreateFolder(folderName);
        ctx.ExecuteQuery();
    }
