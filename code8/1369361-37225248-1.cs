    var list = ctx.Web.Lists.GetByTitle(targetListTitle);
    var items = list.GetItems(CamlQuery.CreateAllItemsQuery());
    ctx.Load(items, icol => icol.Include( i => i["MetaInfo"]));
    //ctx.Load(items);
    ctx.ExecuteQuery();
    foreach (var item in items)
    {
        var metaInfo = (string) item["MetaInfo"];
        var metaInfoValue = ParseMetaInfo(metaInfo);
        //..
    }
