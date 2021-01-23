    [HttpGet]
    public HttpResponseMessage GetCountries()
    {
        List<Group> groups = (from g in db.QR_Groups
                                   select new Group
                                   {
                                       name = g.name,
                                       code = g.code
                                   }).ToList();
        return Request.CreateResponse(HttpStatusCode.OK, groups);
    }
