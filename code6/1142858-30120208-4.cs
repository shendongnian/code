    public static IEnumerable<MyObject> RemoveMaxOpIdInIdGroup(List<MyObject> items)
    {
        var result = items
            // Group by id
            .GroupBy(item =>
                item.Id)
            // Select each group and max operation id in each group
            .Select(group =>
                new { group, maxOperationId = group.Max(item => item.OperationId) })
            // From each group select the item where opid is not max for this 
            // group or if the group has only one item
            .SelectMany(groupWithMax =>
                groupWithMax
                    .group
                    .Where(item =>
                        (item.OperationId != groupWithMax.maxOperationId) ||
                        (groupWithMax.group.Count() == 1)));
        return result;
    }
