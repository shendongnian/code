    public void Persons(string firstName, string lastName, int? age) {            
      var query = loudTable.CreateQuery<CustomTableEntity>();
      if (firstName != null) {
        query = query.Where(p => p.FirstName == firstName);
      }
      if (lastName != null) {
        query = query.Where(p => p.LastName == lastName);
      }
      if (age.HasValue) {
        query = query.Where(p => p.Age == age.Value);
      }
      // then use the query
    }
