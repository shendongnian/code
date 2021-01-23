    [HttpGet]
    [Route("GetByName/{name:string}")]
    public T GetByName(string name)
    {
        return repository.GetByName(name);
    }
