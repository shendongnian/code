    Public IHttpActionResult GetStudent(int id)
    {
     Student model = new Student();
     //Fetch data from DB and assign it to model
     return Ok(TheModelFactory.Create(model));
    }
