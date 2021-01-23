    private Expression<Func<User, bool>> BuildIdQuery(
        Expression<Func<User, bool>> predicate,
        int? id,
        Func<User, int> propertySelector)
    {
        if(id.HasValue)
        {
            // First(...) with throw an exception if there are no items
            // matching the predicate; Any() is the proper way to do it.
            return predicate.Or(m => m.Any(a => propertySelector(a) == id);
        }
        return predicate;
    }
    Expression<Func<User, bool>> BuildSearchTermQuery(
        Expression<Func<User, bool>> predicate, string searchTerm)
    {
        if(String.IsNullOrWhiteSpace(searchTerm)
            return predicate;
        // You don't need to use ToUpper() unless you 
        // know that your database performs case-sensitive comparison
        return predicate.Or(m => m.field1.Contains(searchTerm))
            .Or(m => m.field2.Contains(searchTerm)); // etc.
    }
