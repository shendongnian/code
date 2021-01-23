    public IEnumerable<int> GetDocNamesForFilterId(int id)
    {
        using (var db = new ARXEntities())
        {
            var selectedIds = (from t in db.ServiceAccountFilters
                        where t.FilterId == id
                        select t.DocNameId).ToList();
            return selectedIds;
        }
    } 
