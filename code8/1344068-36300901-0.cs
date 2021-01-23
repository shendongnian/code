    public string Get(int? id, string firstName, string lastName, string address)
    {
       if (id.HasValue)
          GetById(id);
       else if (string.IsNullOrEmpty(address))
          GetByName(firstName, lastName);
       else
          GetByNameAddress(firstName, lastName, address);
    }
