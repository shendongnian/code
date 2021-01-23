    var tree = Descend(dt.AsEnumerable(), 1, 3);
    private static System.Collections.IEnumerable Descend(IEnumerable<DataRow> data, int currentLevel, int maxLevel)
    {
        if (currentLevel > maxLevel)
        {
            return Enumerable.Empty<object>();
        }
        return from item in data
                group item by new
                {
                    key = item.Field<string>("Key_L" + currentLevel),
                    name = item.Field<string>("L" + currentLevel)
                } into rowGroup
                select new
                {
                    key = rowGroup.Key.key,
                    name = rowGroup.Key.name,
                    children = Descend(rowGroup, currentLevel + 1, maxLevel)
                };
    }
