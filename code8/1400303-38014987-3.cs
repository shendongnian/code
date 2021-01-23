    var dataset = _mediaRepository.GetAll()
                       .Where(d => d.matter== matterId)
                       .Select(d => new
                         {
                             d.Id,
                             d.Name,
                             d.ParentMediaId,
                         })
                       .OrderBy(d => d.ParentMediaId)
                       .ThenBy(d => d.Id)
                       .ToList();
                       
