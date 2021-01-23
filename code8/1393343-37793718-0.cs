    [HttpPost]
    public IActionResult Post([FromBody]string something)
    {    
       ...
        try{
        }
        catch(Exception e)
        {
             return StatusCode(500);
        }
    }
