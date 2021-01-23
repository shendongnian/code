    var properties = _propertyRepository
                    .GetAll()
                    .AsNoTracking()
                    .Include(p => p.Address).
                    .Select(s=> new PropertyListDto{
                            Id = s.Id
                            CountyListDto = s.CountyListDto 
                             ...    
    
    
    })
