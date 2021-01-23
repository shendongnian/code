    ClientContext context = new ClientContext(SharePointURL);
    
    List AssetList = context.Web.Lists.GetByTitle(SharePointListTitle);
    
    context.Load(AssetList);
    context.ExecuteQuery();
    
    CamlQuery query = CamlQuery.CreateAllItemsQuery();
    ListItemCollection items = AssetList.GetItems(query);
    
    //Retrieve all items in the ListItemCollection from List.GetItems(Query). 
    context.Load(items,
        itms => itms.Include(
            i => i["GUID"],
            i => i["Title"],
            i => i["FileLeafRef"],
            i => i["FileRef"],
            i => i["VideoSetDescription"],
            i => i["Live_x0020_Date"],
            i => i["Expiration_x0020_Date0"],
            i => i["Is_x0020_Active"],
            i => i["Tags"],
            i => i["AlternateThumbnailUrl"]
            )
        );
    
    context.ExecuteQuery();
