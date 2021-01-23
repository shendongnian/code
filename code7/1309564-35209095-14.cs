    var query = _mongoDatabase.GetCollection<Incident>("Incident")
                              .Aggregate()
                              .Project(i=>new{Id= i.Id,
                                              ObjectIds= i.IncidentFrames.Select(f=>f.Objects.Select(o=>o.Id))}).ToList();
    var result = query.Select(e => new IncidentDto { Id=e.Id, ObjectsCount = e.ObjectIds.SelectMany(l => l).Distinct().Count() });
