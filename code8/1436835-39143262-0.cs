    [HttpGet] // if you are calling via GET verb
    [Route("Employees")]
    public IHttpActionResult Employees()
    {
    }
    [HttpGet] // if you are calling via GET verb
    [Route("Details/{id}"]
    public IHttpActionResult Details(int id)
    {
    }
    [HttpGet] // if you are calling via GET verb
    [Route("TeamInfo/{id}"]
    public IHttpActionResult TeamInfo(int id)
    {
    }
    [HttpGet] // if you are calling via GET verb
    [Route("DetailsForTeam/{id}"]
    public IHttpActionResult DetailsForTeam(int id)
    {
    }
