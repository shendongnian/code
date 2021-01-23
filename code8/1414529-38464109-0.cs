    var VM = _groupManager.Groups
        .Where(g => g.Id == id)
        .Select(g => new MyGroupViewModel()
        {
            Roles = g.ApplicationGroupRoles
        })
        .FirstOrDefault();
