    public List<Customer> GetFirstNameAndLastNameOfMales()
    {
        var p = new Program();
        return p.IQueryableGetAll()
                .Where(r => r.Gender == "M")
                .Select(r => new Customer { 
                        FirstName = r.FirstName, 
                        LastName = r.LastName
                }).ToList();
    }
