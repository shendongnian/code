    [HttpPost]
    public IActionResult Post([FromBody] string something)
    {    
        //...
        try {
            DoSomething();
        }
        catch(Exception e)
        {
             LogException(e);
             return StatusCode(500);
        }
    }
