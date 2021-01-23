    var list = ctx.Web.Lists.GetByTitle(listTitle);
    var item = list.GetItemById(itemId);
    
    ctx.Load(item);
    ctx.ExecuteQuery();
