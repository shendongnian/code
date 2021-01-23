    [HttpGet]
    public async Task<IHttpActionResult> MostPopular([FromODataUri] DateTimeOffset from, [FromODataUri] IEnumerable<ServiceCodes> serviceCodes, 
                                                     [FromODataUri] IEnumerable<int> serviceUnits,
                                                     [FromODataUri] string searchCcl, [FromODataUri] int listLength = ListLengthDefault)
    { // ...
    }
