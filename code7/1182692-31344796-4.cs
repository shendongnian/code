    public IHttpActionResult Search([FromBody]string query)
    {
        var companies = companyRepository.Get().Where(c => c.Name.ToLower().Contains(query.ToLower()));
        var people = personRepository.Get().Where(c => c.FirstName.ToLower().Contains(query.ToLower()) || c.LastName.ToLower().Contains(query.ToLower()));
        List<SearchResult> results = new List<SearchResult>();
        foreach(Company company in companies)
            results.Add(new SearchResult { ID = company.ID, Name = company.Name, Type = "Company" });
        foreach (Person person in people)
            results.Add(new SearchResult { ID = person.ID, Name = person.FirstName + " " + person.LastName, Type = "Person" });
        return Ok(results);
    }
