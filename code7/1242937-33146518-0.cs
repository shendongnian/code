    public IEnumerable<DTO> GetDtos(IQueryable<OtherObject> otherObjects) 
    {
       var ids = otherObjects.Select(x => x.SomeId);
       return from item in _someRepository.GetAll()
              where ids.Contains(item.SomeId)
              let otherObjectProperty = otherObjects.FirstOrDefault(x => x.SomeId == item.SomeId).OtherObjectEntity1
              select new DTO()
              {
                EntityProperty1 = item.EntityProperty1,
                EntityProperty2 = item.EntityProperty2, 
                EntityProperty3 = item.EntityProperty3,
                OtherObjectEntity1 = otherObjectProperty 
        };
    }
