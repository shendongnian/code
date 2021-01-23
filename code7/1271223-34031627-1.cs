        using (var db = new myDatabase())
        {
            var itemLists = db.GetAllItem().ToList();
            var userSubmittedItems = db.GetAllUserItem("LoginID").ToList();
            if (userSubmittedItems.Count > 0)
            {
                foreach (var submittedItems in userSubmittedItems)
                {
                    foreach (var item in itemLists)
                    {
                        int itemID = item.ItemID;
                        int userItemID = userSubmittedItems.UserItemID;
                        if (itemID == userItemID && item.OneTime == true)
                        {
                            itemLists.Remove(item);
                            db.ItemEntity.Remove(item); // mark for delete
                        }
                    }
                }
                db.SaveChanges(); // all marked items, if any, will now 
                                  //  be committed in a db call
            }
