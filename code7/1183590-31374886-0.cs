    MyProjectItemTag existingItemTag = 
      (from p in context.ItemTags
        .Include(p => p.MyProjectGenre)
        .Include(p => p.MyProjectCountry)
       where p.MyProjectUser.UserId == ItemTag.MyProjectUser.UserId 
         && p.MyProjectItem.ItemId == MyProjectItem.ItemId
       select p).FirstOrDefault();
