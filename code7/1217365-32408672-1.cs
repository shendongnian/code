    ExtendedPropertyDefinition EntryIDProperty = new ExtendedPropertyDefinition(0x0FFF, MapiPropertyType.Binary);
    ItemView item_view = new ItemView(10) { PropertySet = new PropertySet(ItemSchema.Id, EntryIDProperty) };
    var result = service.FindItems(WellKnownFolderName.Inbox, item_view);
    foreach (var item in result.Items)
    {
        byte[] entry_id = (byte[])item.ExtendedProperties.Single(x => x.PropertyDefinition == EntryIDProperty).Value;
        string entry_id_hex = ByteArrayToHexString(entry_id); //This is the entry ID that you should store
    }
