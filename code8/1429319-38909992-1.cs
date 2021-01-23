    public HttpResponseMessage Get()
    {
       var db = new StudyDataContext();
       var data = db.details.Select(x => new CategoryDto { 
                                                        Category = x.Category,
                                                        SessionStartDate  = x.SessionStartDate,
                                                        SessionNumber = x.SessionNumber }
                                   ).ToList();
       return Request.CreateResponse(HttpStatusCode.OK, data);
    }
