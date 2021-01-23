    public IEnumerable<DTO> GetDtos(IQueryable<OtherObject> otherObjects) 
    {
        return _someRepository.GetAll()
            .Where(a => otherObjects.Select(b => b.SomeId).Contains(a.SomeId))
            .Select(d => new DTO()
                {
                    EntityProperty1 = d.EntityProperty1
                    EntityProperty2 = d.EntityProperty2 
                    EntityProperty3 = d.EntityProperty3,
                    OtherObjectEntity1 = otherObjects.FirstOrDefault(a => a.SomeId == e.SomeId).OtherObjectEntity1
                })
            .ToList();
    }
