    [HttpGet]
    public async Task<IHttpActionResult> Get(int id)
    {
        var animal = await animalManager.GetAsync(id);
    
        return Ok(animal);
    }
