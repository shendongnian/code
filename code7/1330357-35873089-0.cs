    using (new Sitecore.SecurityModel.SecurityDisabler())
    {
        Item newItem = Sitecore.Context.Item;
    
        newItem.Editing.BeginEdit();
    
        MultilistField mlf = newItem.Fields["FieldName"];
        mlf.Add(ItemToAdd.ID.ToString());
    
        newItem.Editing.EndEdit();
    }
