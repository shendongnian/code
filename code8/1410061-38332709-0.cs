    using (MyDb db = new MyDb())
    {
        var query = db.EntityManagerRoleAssignments.Where(x => x.EntityManager.ManagerId == userId);
        var entityGroups = query.GroupBy(x => x.EntityManager.EntityId);
        var result = entityGroups.ToDictionary(e => e.Key, 
                                               g => g.Select(x => x.RoleId).ToArray()
                                              );
        return result;
    }
