    [HttpGet]
    public IHttpActionResult GetActivationStatus([FromUri] YourModel yourmodel)
    {
        if (ModelState.IsValid)
        {
             ...
        }
    }
