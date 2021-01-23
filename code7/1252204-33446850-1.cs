    [HttpGet, Route("/api/yourRoute")]
    public async Task<IHttpActionResult> GetListOfYourObjects(string fields = null)
    {
        try
        {
            var yourObject = await repo.GetYourListFromRepo();
    
            if (fields.HasValue())
            {
               return Ok(yourObject.ToDataShape(fields, PropertyFormat.CamelCase));
            }
    
            return Ok(yourObject);
        }
        catch (Exception)
        {
             return InternalServerError();
        }
    }
