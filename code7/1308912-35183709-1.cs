    static List<List<int>> Group2(List<int> data)
    {
        return data.Aggregate(new List<List<int>>(), (list, item) => 
        {
            if (list.Count == 0 || list[list.Count - 1][0] != item)
            {
                list.Add(new List<int> { item });
            }
            else
            {
                list[list.Count - 1].Add(item);
            }
            return list;
        });
    }
