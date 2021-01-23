    using (var context = new MyContext())
    {
        var parent = context.Parents.Include(p => p.Children)
        .SingleOrDefault(p => p.Id == parentId);
        foreach (var child in parent.Children.ToList())
        context.Children.Remove(child);
        context.SaveChanges();
    }
