    var tasks = items.Select(item =>
                         {
                             var clone = item.MakeCopy();
                             clone.Id = Guid.NewGuid();
                             return dbAccess.SaveAsync(clone);
                         })
                     .ToList();
