    public IEnumerable<DTO> GetDtos(IQueryable<OtherObject> otherObjects) 
    {
       var ids = otherObjects.Select(x => x.SomeId);
       return _someRepository.GetAll()
              .Where(x => ids.Contains(x.SomeId)
              .ToList()
              .Select(x =>
                     new DTO()
                     {
                        EntityProperty1 = x.EntityProperty1,
                        EntityProperty2 = x.EntityProperty2, 
                        EntityProperty3 = x.EntityProperty3,
                        OtherObjectEntity1 = otherObjects.FirstOrDefault(p => p.SomeId == x.SomeId).OtherObjectEntity1
                     };
    }
