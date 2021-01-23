    public ActionResult SaveItems(string[] fooItems, int category_id)
    {
        var itemsToRemove = DB.items.Where(e => e.category_id == category_id)
                                    .ToList();
        foreach (var item in itemsToRemove)
        {
            DB.items.Remove(item);
        }
        DB.SaveChanges();
    }
