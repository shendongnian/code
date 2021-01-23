    var query = from e in _repository.GetAll<Entity>();
    
    if (filterInclude.HasValue)
    {
        
        // when filterInclude is null (it means **ALL**), 
        // do not filter otherwise - check the flag
        query = query.Where(entity => entity.Include == filterInclude.Value);
    }
    
    var a = query.Select(entity => new AggregationEntityViewModel { .... });
    
    return a;
