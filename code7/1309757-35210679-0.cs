    public List<SimpleViewModel> NotDeletedParameters
    {
        get
        {
            return Parameters.Where(t => !t.Deleted).ToList();
        }
    }
