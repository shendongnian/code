    public List<V_ScientificNews> GetNewsByFieldName(string value)
    {
        var q = _entities.V_ScientificNews.Where(x=>x.FieldName.Contains(value));
        return q.ToList();
    }
