    [HttpGet]
    [Route("assets")]
    public async Task<HttpResponseMessage> Get([FromUri]SearchCriteria searchCriteria)
    {
    
    if(searchCriteria == null)
        searchCriteria = new SearchCriteria();
    
    }
