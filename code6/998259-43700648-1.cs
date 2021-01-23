    public School Insert(School newItem)
    {
        using (var context = new DatabaseContext())
        {
            context.Set<School>().Add(newItem);
            // use the following statement so that City won't be inserted
            context.Entry(newItem.City).State = EntityState.Unchanged;
            context.SaveChanges();
            return newItem;
        }
    }
