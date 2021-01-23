    public ActionResult SaveItems(string[] fooItems, int category_id)
    {
         var itemsToRemove = DB.items.Where(i => i.category_id == category_id).ToList();
    
         DB.items.RemoveRange(itemsToRemove);
         DB.SaveChanges();
    }
