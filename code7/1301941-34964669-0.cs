    //Calculate valid IDs from the dictionary
    List<int> valid_ids =
        filterDictionary
            .Where(x => x.Key == "ID")
            .SelectMany(x =>
            {
                if (x.Value is int)
                {
                    return new[] {(int) x.Value};
                }
                return (IEnumerable<int>) x.Value;
            }).ToList();
    //Calculate valid NAMEs from the dictionary
    List<string> valid_names =
            filterDictionary
            .Where(x => x.Key == "NAME")
            .SelectMany(x =>
            {
                if (x.Value is string)
                {
                    return new[] { (string)x.Value };
                }
                return (IEnumerable<string>)x.Value;
            }).ToList();
    IEnumerable<Business> query = businessList;
    if (valid_ids.Count > 0)
        query = query.Where(x => valid_ids.Contains(x.ID));
    if(valid_names.Count > 0)
        query = query.Where(x => valid_names.Contains(x.NAME));
    var result = query.ToList();
