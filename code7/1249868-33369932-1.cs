    [HttpGet]
    public List<ContactDTO> AllContacts()
    {
        return repository.GetAllContacts().ToList();
    }
