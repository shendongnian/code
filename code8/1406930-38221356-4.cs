    private void LoadChildren(DbContext context, Person person)
    {
      var childCollection = context.Entry(person).Collection(x => x.Children);
      if(!childCollection.IsLoaded)
      {
        childCollection.Load();
        foreach(var child in person.Children)
          LoadChildren(context, child);
      }
    }
    /* ... */
    using (var ctx = new PersonContext())
    {
        var result = ctx.People
              .Include(x => x.Parent)
              .FirstOrDefault();
        LoadChildren(ctx, result);
        return result;
    }
