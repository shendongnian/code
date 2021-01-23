    public IEnumerable<MyClass> GetUpdatedVals(List<MyClass> myVals, string groupName)
    {
        return myVals
            .Where(v => v.GroupName == groupName)
            .OrderBy(v => v.Id)
            .ThenBy(v => v.Dt)
            .GroupAdjacentBy((x, y) => x.Val == y.Val && x.Id == y.Id)
            .Select(g => g.First());
    }
