    private EfContext db = new EfContext();
    // GET api/<controller>
    public ActionResult GetGroups()
    {
        var groupList = (from g in db.QR_Groups
        select new
        {
            name = g.name,
            code = g.code
        }).AsQueryable();
        return Content(JsonConvert.SerializeObject(groupList));
    }
