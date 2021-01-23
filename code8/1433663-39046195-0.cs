    public List<MyObject> FilteringFunction(List<MyObject> listToFilter, List<Filter> filters)
    {
        Func<MyObject, bool> predicate =
            x =>
                filters.All(f => x.Value.Contains(f.Value));
        
        return listToFilter.Where(predicate).ToList();
    }
