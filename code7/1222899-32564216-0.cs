    using (var ctx = new ClientContext(webUri))          
    {
            
        var folder = ctx.Web.GetFolderByServerRelativeUrl("/Shared Documents/Archive");
        var folderItem = folder.ListItemAllFields;
        //grant Read permissions to 'Everyone' Sec Group  
        var everyoneSecGroup = ctx.Web.SiteUsers.GetById(4);     //get Everyone security group            
        ShareListItem(folderItem, everyoneSecGroup, "Read");
    }
