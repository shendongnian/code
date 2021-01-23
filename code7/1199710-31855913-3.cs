    public IHttpActionResult Post([FromUri]Guid id, [FromUri]string firstname, [FromUri]string lastname)
    {
        // validate your parameter in some way
        if (id.Equals(Guid.Empty)) return BadRequest("id must not be null or an empty GUID");
        if (string.IsNullOrEmpty(firstname)) return BadRequest("firstname must not be null or empty");
        if (string.IsNullOrEmpty(lastname)) return BadRequest("lastname must not be null or empty");
        // create your person object
        var person = New Person {
            id = id,
            firstName = firstname,
            lastname = lastname,
        };
        // go off and save the person
        var createdPerson = myPersonRepository.Save(person);
        if (createdPerson == default(Person)) return InternalServerError();
        return CreatedAtRoute("DefaultApi", new { id = createdPerson.Id }, createPerson);
    }
