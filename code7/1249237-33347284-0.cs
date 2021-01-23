    public static List<string> GetList(List<string> in_list, int max)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        int itemsAdded = 0;
        in_list.OrderBy(x => x).Aggregate(dict, (list, aggr) =>
        {
            if (itemsAdded++ < max)
            {
                if (dict.ContainsKey(aggr))
                    dict[aggr]++;
                else
                    dict.Add(aggr, 1);
            }
            return list;
        });
        //dict now contains only each required elements with the number of occurrences allowed of that element
        List<string> out_list = in_list.Select(x =>
        {
            return (dict.ContainsKey(x) && dict[x]-- > 0 ? x : "n");
        }).ToList();
        return out_list;
    }
