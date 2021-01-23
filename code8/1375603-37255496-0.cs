    public IHttpActionResult GetBoilerReading(int id)
    {
         var BoilerReading = ExecuteQuery(); //you will probably want this to take an int parameter and add a WHERE clause to your query.
         if (BoilerReading == null)
         {
             return NotFound();
         }
         return Ok(BoilerReading);
     }
