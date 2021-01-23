    public static IEnumerable<List<object>> PartitionByTypes(List<object> values)
    {
        int count = 0;
        return values.Select((o, i) => new 
            { 
                Object = o, 
                Group = (i == 0 || o.GetType() == values[i - 1].GetType()) ? count : ++count 
            })
            .GroupBy(x => x.Group)
            .Select(g => g.Select(x => x.Object).ToList());
    }
