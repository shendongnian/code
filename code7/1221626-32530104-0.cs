    var service = new SitecoreService("master");
    var newItem = service.Create<IArticle, ISitecoreItem>(parentItem, "New item name");
    //populate the properties
    newItem.Introduction = "In the beginning there was a...";
    service.Save(newItem);
