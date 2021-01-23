    public static IQueryable<ISecurable> FilterByACL(this IQueryable<ISecurable> securables,
        User user, int requiredAction)
    {
        var userId = user.Id;
        var groupIds = user.Workgroups.Select(w => w.Id).ToArray();
        return securables.Where(s =>
            s.ACL.ACEntries.Any(e =>
                (e.PrincipalId == userId || groupIds.Contains(userId)) &&
                (e.AllowedActions & requiredAction) == requiredAction));
    }
