    public virtual ActionResult GetRecordsJsonResultAll()
    {
        var userBusinessLogic = InterfaceResolver.ResolveWithTransaction<IUserBusinessLogic>();
        var records = userBusinessLogic.GetAll().Select(x => new
        {
            x.Id,
            x.FirstName,
            x.LastName,
            x.Email
        }).OrderBy(i => i.Id);
        var serializer = new JavaScriptSerializer();
        serializer.MaxJsonLength = Int32.MaxValue;
        var data = new
        {
            max = records.Count(),
            items = records
        };
        var result = new ContentResult
        {
            Content = serializer.Serialize(data),
            ContentType = "application/json"
        };
        return result;
    }
