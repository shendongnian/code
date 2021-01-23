    // Open client context to the site
    var clientContext = new ClientContext(siteUrl);
    
    // Use client context to open the list
    var oList = clientContext.Web.Lists.GetByTitle("VSList");
    var listCreationinformation = new ListItemCreationInformation();
    var oListItem = oList.AddItem(listCreationinformation);
    
    // Push information to individual tables in the selected list
    oListItem["Title"] = value1;
    oListItem["qf2a"] = value2;
    oListItem["_x0077_830"] = value3;
    oListItem["u6zl"] = value4;
    
    oListItem.Update();
    clientContext.ExecuteQuery();
