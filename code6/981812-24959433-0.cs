    var requestedKeys = request.Keys;
    var existingKeys = _context.WebTaskGroups
                     .Where(x => x.TaskGroupNameKey == key && 
                         requestedKeys.Contains(x.TaskKey))
                     .Select(x => x.TaskGroupNameKey))
                     .ToList();
