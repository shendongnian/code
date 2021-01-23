    var objects = _mediaRepository.GetAll()
                       .Where(d => d.matter== matterId)
                       .Select(d => new
                        {
                            d.Id,
                            d.Name,
                            d.ParentMediaId,
                        });
    var dataset = objects.OrderBy(o => o.ParentMediaId ?? o.Id)
                         .ThenBy(o => o.ParentMediaId)
                         .ToList();
