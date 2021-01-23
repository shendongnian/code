    [HttpPost]
    public IHttpActionResult PostData()
    {
        var parms = Request.Content.ReadAsStringAsync().Result;
        // Submit parms to third-party api.
        return Ok();
    }
