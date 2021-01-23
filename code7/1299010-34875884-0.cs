     var myItem = Sitecore.Context.Item;
     using (new Sitecore.Globalization.LanguageSwitcher("da-DK"))
     {
        myItem = myItem.Database.GetItem(myItem.ID);
     }
