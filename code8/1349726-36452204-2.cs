    [Route("api/subjects/ContactValue?contactValue={contactValue}")]
    public IEnumerable<Subject> GetByContactValue(string contactValue)
    {
        return repository.GetByContactValue(contactValue);
    }
