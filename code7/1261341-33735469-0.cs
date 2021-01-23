    [HttpGet, Route("api/yourroute")]
    public IHttpActionResult GetSomeData()
    {
        try
        {
           var data = new Dictionary<string, dynamic>();
           data.Add("field1", "test");
           data.Add("field2", 123);
    
           var fieldName = someCondition == true? "someArray" : "someOtherArray";
           data.Add(fieldName, yourArray);
    
           return Ok(data);
        }
        catch
        {
            return InternalServerError();
        }
    }
