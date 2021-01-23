    public IEnumerable<MyClass> GetUpdatedVals(List<MyClass> myVals, string groupName)
    {
        var filteredVals = myVals.Where(v => v.GroupName == groupName).ToList();
    
        return filteredVals
            .OrderBy(v => v.Id)
            .ThenBy(v => v.Dt)
            .GroupAdjacentBy((x, y) => x.Val == y.Val)
            .Select(g => g.First());
    }
