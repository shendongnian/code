    using (var ctx = new ClientContext(webUri))
    {
        var list = ctx.Web.Lists.GetByTitle(listTitle);
        for (var year = 2000; year <= 2015; year++)
        {
           list.CreateFolder(year.ToString());
        }
        ctx.ExecuteQuery();
    }
