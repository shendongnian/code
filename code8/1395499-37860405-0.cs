    public IHttpActionResult Save(item)
    {
        try
        {
            result = MyRepository.Save(item);
            return Ok(result);
        }
        catch
        {
            return BadRequest("Error message");
        }
    }
