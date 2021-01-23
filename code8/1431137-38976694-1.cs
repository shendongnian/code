    public IList<T> GetByIds(IEnumerable ids)
    {
        if (ids != null)
        {
            var urnKeys = ids.Map(x => client.UrnKey<T>(x));
            if (urnKeys.Count != 0)
                return GetValues(urnKeys);
        }
        return new List<T>();
    }
    public IList<T> GetAll()
    {
        var allKeys = client.GetAllItemsFromSet(this.TypeIdsSetKey);
        return this.GetByIds(allKeys.ToArray());
    }
