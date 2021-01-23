    public void ResetFields(List<Item> items, List<string> fields)
    {
        if (items.Any() && fields.Any())
        {
            foreach (Item item in items)
            {
               ResetFieldsOnItem(item, fields);
            }
        }
    }
     
    public void ResetFieldsOnItem(Item item, List<string> fields)
    {
        if (item != null && fields.Any())
        {
            using (new Sitecore.Security.Accounts.UserSwitcher(YourElevatedUserAccount, true))
            {
                item.Editing.BeginEdit();
     
                foreach (string field in fields)
                {
                    item.Fields[field].Reset();
                }
     
                item.Editing.EndEdit();
            }
        }
    }
