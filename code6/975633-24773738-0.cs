    private void UpdateItemCategories(Item item, ItemViewModel viewModel)
    {
        //Check whether item is already linked with some category
        bool sendEmail;
        if(item.Linked == false)
        {
          sendEmail=true;
        }
        //Above code is for your understanding. you can simply use: bool sendEmail = !item.Linked;
        var itemCategories = item.Categories.ToList();
        foreach (var category in itemCategories)
        {
            if (!viewModel.Categories.Any(t => t.CategoryId == category.CategoryId))
            {
                item.Categories.Remove(category);
                item.Linked = false;
            }
        }
    
        foreach (var category in viewModel.Categories)
        {
            if (!itemCategories.Any(t => t.CategoryId == category.CategoryId))
            {
                var itemCategory = category.ToCategory();
                db.Categories.Attach(itemCategory);
                item.Categories.Add(itemCategory);
                item.Linked = true;
            }
        }
    
        if (sendEmail)
        {
            //Send notification e-mail
            UserMailer.Notification(item).Send();
        }
    }
