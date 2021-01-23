    public List<State> GetApprovedStateList(DateTime effectiveDate)
    {
        using ( var db = new Context())
        {
            return (from a in db.StateProductList
                         join b in db.States on a.stateID equals b.stateID
                         where a.effectiveDate <= effectiveDate
                         select b).ToList();
        }
    }
