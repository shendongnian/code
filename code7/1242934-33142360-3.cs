    var result = 
        someRepository.GetAll()
            .Where(a => otherObjects.Select(b => b.SomeId).Contains(a.SomeId))
            .Select(d => new DTO()
                {
                    EntityProperty1 = d.EntityProperty1
                    EntityProperty2 = d.EntityProperty2 
                    EntityProperty3 = d.EntityProperty3
                }).
     .ToList()
