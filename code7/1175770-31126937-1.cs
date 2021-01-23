    private EfContext db = new EfContext();
    
    // GET api/<controller>
    public IEnumerable<QR_Group_Return> GetGroups()
    {
        var result = (from g in db.QR_Groups
                     select new QR_Group_Return {
                               name = g.name,
                               code = g.code,
                               // map your other properties also
                               }).ToList();
        return result.ToList();
    }
