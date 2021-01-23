    // As a best practice, limit the properties returned to only those that are required.
    PropertySet propSet = new PropertySet(BasePropertySet.IdOnly, ItemSchema.Body);
    
    // Bind to the existing item by using the ItemId.
    // This method call results in a GetItem call to EWS.
    Item item = Item.Bind(service, itemId, propSet);
    
    // item.Body.value = "<html><body> Example body </body></html>"
    
    // Update the style of the mail's body.
    item.Body.value = "<html><body style='font-family: Arial'> Example body </body></html>"
    
    // Save the updated email.
    // This method call results in an UpdateItem call to EWS.
    item.Update(ConflictResolutionMode.AlwaysOverwrite);
