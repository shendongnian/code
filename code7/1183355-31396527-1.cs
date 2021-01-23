    [HttpPost]
    public bool IsEmailAvailable(ODataActionParameters parameters)
    {
        ...
    }
    
    [HttpPost]
    public IHttpActionResult IsEmailAvailable(int key, ODataActionParameters parameters)
    {
        ...
    }
