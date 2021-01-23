    ItemView view = new ItemView(100);
    FindItemsResults<Item> results = service.FindItems(folder, "Has attachment:true", view);
    foreach (Item item in results.Items)
    {
      if (item is EmailMessage)
        {
          // Get the item and FileAttachments in the same way.
        }
    }
