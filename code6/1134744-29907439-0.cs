        foreach (var entity in typeMapper.GetItemsToGenerate<EntityType>(itemCollection))
        {
            fileManager.StartNewFile(entity.Name + ".cs");
        	var entitySet = container.BaseEntitySets.OfType<EntitySet>().FirstOrDefault(set => set.ElementType == entity);
            ...
        }
