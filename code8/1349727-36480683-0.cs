    [Route("api/subjects/ContactValue")]
    public IEnumerable<Subject> GetByContactValue([FromUri]string contactValue)
    {                                 
        return repository.GetByContactValue(contactValue);
    }
