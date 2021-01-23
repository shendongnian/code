    [HttpGet]
    [Route("Products/Year/{yearId}")]
    public async Task<IEnumerable<Make>> GetProductsYearId(int yearId)
    {
        ...
    }
    [HttpGet]
    [Route("Products/Make/{makeid}")]
    public async Task<Make> GetProductById(int makeid) 
    {
         ... 
    }
