    [Route("api/person")]
    [HttpPost]
    public void UpdatePerson(Models.Person person)
    {
        var mappedPerson = Mapper.Map<Person>(person);
        personRepository.Update(mappedPerson);
    
        //I'd suggest returning some type of IHttpActionResult here, even if it's just a status code.
    }
