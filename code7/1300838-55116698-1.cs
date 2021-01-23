    //Define a property set
    view.PropertySet = new PropertySet(BasePropertySet.FirstClassProperties, ContactSchema.EmailAddress1);
    //get all contact items
    var findContact = service.FindItems(new FolderId("AXXX"), view);
    service.LoadPropertiesForItems(findContact, view.PropertySet);
    foreach (Contact item in findContact.Items)
    {
        EmailAddress emAdd;
        var emailVal = item.EmailAddresses.TryGetValue(EmailAddressKey.EmailAddress1, out emAdd);
        //do your functionality
    }
