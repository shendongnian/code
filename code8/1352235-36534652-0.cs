    [HttpGet]
    [ODataRoute("States(ProvinceStateCode={stateCode},CountryCode={countryCode})")]
    [EnableQuery]
    public IHttpActionResult Get([FromODataUri] string stateCode, [FromODataUri] string countryCode)
    {
        var result = db.ProvinceStates.FirstOrDefault(c => c.ProvinceStateCode == stateCode && c.CountryCode == countryCode);
        if (result == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }
