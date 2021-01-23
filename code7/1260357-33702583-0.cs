    PropertySet itempropertyset = new PropertySet(BasePropertySet.FirstClassProperties);
    itempropertyset.RequestedBodyType = BodyType.Text;
    ItemView itemview = new ItemView(1000);
    itemview.PropertySet = itempropertyset;
    
    FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, "subject:TODO", itemview);
    Item item = findResults.FirstOrDefault();
    item.Load(itempropertyset);
    Console.WriteLine(item.Body);
