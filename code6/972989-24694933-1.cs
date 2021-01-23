    public void UpdateItems<TEntity,TRelated>(
        // Entity with new list of related items
        TEntity entity, 
        // Selector for the key of the entity element
        Func<TEntity,object[]> entityKeySelector,
        // Selector for the related items of the Property
        Expression<Func<TEntity,ICollection<TRelated>>> relatedItemsSelector,
        // Comparer of related items
        Func<TRelated, TRelated, bool> relatedItemsComparer)
        where TEntity : class
        where TRelated : class
    {
        using (var context = new TCtx())
        {
            // get the Keys for the entity
            object[] entityKeyValues = entityKeySelector.Invoke(entity);
            // gets the entity entity from the DB
            var entityInDb = context.Set<TEntity>().Find(entityKeyValues);
            // loads the related entities from the DB
            context.Entry(entityInDb).Collection(relatedItemsSelector).Load();
            // gets the list of properties in the passed entity
            var newRelatedItems 
                = relatedItemsSelector.Compile().Invoke(entity);
            // Gets the list of properties loaded from the DB
            var relatedItemsInDb 
                = relatedItemsSelector.Compile().Invoke(entityInDb);
            // Remove related elements
            foreach (var relatedInDb in relatedItemsInDb)
                if (!newRelatedItems.Any(item => relatedItemsComparer
                     .Invoke(relatedInDb, item)))
                {
                    // If the related intem in DB is not in the entity, remove it
                    relatedItemsInDb.Remove(relatedInDb);
                }
            // Add new types
            foreach (var item in newRelatedItems)
                if (!relatedItemsInDb.Any(itemInDb => relatedItemsComparer
                    .Invoke(itemInDb, item)))
                {
                    // Attach the item to the Set
                    context.Set<TRelated>().Attach(item);
                    // If the related item is not in the DB add it
                    relatedItemsInDb.Add(item);
                }
            context.SaveChanges();
        }
    }
