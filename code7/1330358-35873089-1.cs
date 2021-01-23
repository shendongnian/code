    using (new Sitecore.SecurityModel.SecurityDisabler())
    {
    
        Item newItem = Sitecore.Context.Item;
    
        newItem.Editing.BeginEdit();
    
        MultilistField mlf = newItem.Fields["FieldName"];
        
        // adding an item
        mlf.Add(ItemToAdd.ID.ToString());
    
        // removing an item
        mlf.Remove(ItemToRemove.ID.ToString());
    
        newItem.Editing.EndEdit();
    }
