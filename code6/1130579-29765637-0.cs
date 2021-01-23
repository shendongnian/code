    [HttpPost]
    public HttpResponseMessage SelectEmployeeList(Empdet empdet)
    {
        HttpResponseMessage response;
        Collection<Empdet> Empdets =new Collection<Empdet>( db.Empdets.ToList());
        return Request.CreateResponse(HttpStatusCode.OK, Empdets);
    }
     return Response;
