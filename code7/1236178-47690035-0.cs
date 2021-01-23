    public List<object> Search(string colour, string size, string name)
    {
        var query = from c in MyTable
            where
                (string.IsNullOrEmpty(colour) || c.colour == colour) &&
                (string.IsNullOrEmpty(size) || c.size == size) &&
                (string.IsNullOrEmpty(name) || c.name == name)
            select c;
        return query.ToList();
    }
