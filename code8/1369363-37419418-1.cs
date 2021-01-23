    var list = ctx.Web.Lists.GetByTitle(targetListTitle);
    var items = list.GetItems(CamlQuery.CreateAllItemsQuery());
    ctx.Load(items, icol => icol.Include( i => i[MetaInfoFields.MetaInfoFieldName]));
    //ctx.Load(items);
    ctx.ExecuteQuery();
    
    var docProperties = GetDocMetaProperties(listItem[MetaInfoFields.MetaInfoFieldName]);
    
    var title = docProperties[MetaInfoFields.Title];    
    var createdBy = docProperties[MetaInfoFields.Author];    
    var modifiedBy = docProperties[MetaInfoFields.ModifiedBy];    
    var type = docProperties[MetaInfoFields.DocumentType];
