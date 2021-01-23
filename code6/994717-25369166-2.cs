    EntityCache.Instance.LolCatDtos = new DbContext().LolCats.Select(x =>
        new LolCatDto
        {
            Id = x.Id,
            Name = x.Name, 
            Description = x.Description,
            //...
        }).ToList();
