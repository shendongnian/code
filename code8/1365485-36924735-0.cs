    for (int i = 0; i < entityNode.AliasEntities.Count; i++) {
       var currentElement = entityNode.AliasEntities.ElementAt(i);
       var loadedAlias = dbContext.Aliases.Local.
             FirstOrDefault(x => x.Alias == currentElement.Alias);
       if (loadedAlias != null) {
             currentElement.Id = loadedAlias.Id;
             entityNode.AliasEntities.ElementAt(i) = loadedAlias;
             dbContext.Entry(loadedAlias).State = EntityState.Unchanged;
       }
    }
