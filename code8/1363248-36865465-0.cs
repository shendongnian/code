    var readings = uow.MeterReadingReadWriteRepository.Query();
    
    var parents = readings
            .Join(readings, child => child.Id, parent => parent.LastMeterReadingId,
                    (child, parent) => new {parent.Id})
            .Distinct()
            .ToDictionary(a => a.Id);
    
    var result = (from m in readings
                      where !parents.Contains(m.Id) 
                      select new
                        {
                           Id = m.Id
                        }).ToList();
