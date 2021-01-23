    // Open client context to the site
    var clientContext = new ClientContext(SharepointUrl);
    
    // Use client context to open the list
    var oList = clientContext.Web.Lists.GetByTitle("Existing Cases");
    var listCreationinformation = new ListItemCreationInformation();
    var oListItem = oList.AddItem(listCreationinformation);
    
    // Push information to individual tables in the selected list
    oListItem["Case_x0020_Number"] = CaseNumber;
    oListItem["Case_x0020_ID"] = CaseId;
    oListItem["Date_x0020_Updated"] = CaseDate;
    
    oListItem.Update();
    clientContext.ExecuteQuery();
