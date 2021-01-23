        var query = collection.AsQueryable();
        if (!string.IsNullOrEmpty(entity.Name))
            query = query.Where(p => p.Name.Contains(entity.Name));
        if (!string.IsNullOrEmpty(entity.Description))
            query = query.Where(p => p.Description.Contains(entity.Description));
        var YourList=query.ToList();
