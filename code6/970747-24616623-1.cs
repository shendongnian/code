    public IEnumerable<SelectListItem> DistinctMethods
    {
        get { return GetDistinctOrderedLogs(t => t.Method); }
    }
    public IEnumerable<SelectListItem> DistinctUsers
    {
        get { return GetDistinctOrderedLogs(t => t.Users); }
    }
