    public ActionResult GetQuery(int queryId)
    {
        var query = 
        return View(SomeFunctionToGetTheQuery(queryId).Select(x => x.Parameters).ToList());
    }
    public ActionResult RunQuery(List<SomeParameterClassName> parameters)
    {
        //some server side validation
    
        //GetQueryResults will add the parameters and execute the query
        return View(GetQueryResults(parameters);
    }
