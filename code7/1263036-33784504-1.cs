    [ResponseType(typeof (List<Report>))]
    public IHttpActionResult UpdateReports(IEnumerable<Reports> reports)
    {
        var results = SaveReports(reports).ToList();
        return Ok(results);
    }
