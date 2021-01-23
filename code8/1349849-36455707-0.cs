    public IEnumerable<MyClass> GetUpdatedVals(List<MyClass> myVals, string groupName)
    {
        return myVals
            .Where(v => v.GroupName == groupName)
            .OrderBy(v => v.Id)
            .ThenBy(v => v.Dt)
            .GroupBy(v => v.Id)
            .Select(g => g.ToList())
            .SelectMany(gList => gList
                .Where((v, idx) => idx == 0 || v.Val != gList[idx - 1].Val));
    }
