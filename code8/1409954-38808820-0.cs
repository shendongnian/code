    using(ItemGroupModel ctx = new ItemGroupModel())
    {
        ItemGroup grp = ctx.ItemGroup.FirstOrDefault();
    
        // call Item.Clear() to remove any entries in the navigation
        // property which translates into any entries in the junction table
        // in the underlying database
        grp.Item.Clear();
        ctx.ItemGroup.Remove(grp);
        ctx.SaveChanges();
    }
