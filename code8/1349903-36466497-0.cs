    String MailboxToAccess = "user@domain.com";            
    ExtendedPropertyDefinition PR_FLAG_STATUS = new ExtendedPropertyDefinition(0x1090, MapiPropertyType.Integer);
    ExtendedPropertyDefinition FlagRequest = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Common, 0x8530, MapiPropertyType.String);
    SearchFilter sfSearchFilter = new SearchFilter.IsEqualTo(PR_FLAG_STATUS, 2);
    PropertySet fiFindItemPropset = new PropertySet(BasePropertySet.FirstClassProperties);
    fiFindItemPropset.Add(FlagRequest);
    FolderId FolderToAccess = new FolderId(WellKnownFolderName.Inbox, MailboxToAccess);
    ItemView ivItemView = new ItemView(1000);
    ivItemView.PropertySet = fiFindItemPropset;
    FindItemsResults<Item> FindItemResults = null;
    do
    {
        FindItemResults = service.FindItems(FolderToAccess, sfSearchFilter, ivItemView);
        foreach (Item itItem in FindItemResults.Items)
        {
            Console.WriteLine(itItem.Subject);
            Object FlagValue = null;
            if (itItem.TryGetProperty(FlagRequest, out FlagValue))
            {
                Console.WriteLine("Flag : " + FlagValue);
            }
        }
        ivItemView.Offset += FindItemResults.Items.Count;
    } while (FindItemResults.MoreAvailable);
