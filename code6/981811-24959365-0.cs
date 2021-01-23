    var existingKeys = request
        .SelectMany(r => r.Keys)
        .SelectMany(tk =>
            _context.WebTaskGroups
                .Where(x.TaskGroupNameKey == key && x.TaskKey == tk)
                .Select(x => x.TaskGroupNameKey))
        .ToList();
