    [HttpGet]
    [Route("deleted/{from:validDate}/{to:validDate}", Name = "GetDeletedData")]
    [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<SimpleClass>), Description = "response")]
    public async Task<HttpResponseMessage> Get(
        [FromUri]string from = "",
        [FromUri]string to = ""
        )
    {
    
    }
