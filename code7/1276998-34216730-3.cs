    [HttpGet]
    public Dictionary<string, Object> Test()
    {
        var person = new Person() { Id = 1, FirstName = "x", LastName = "y", Age = 20 };
        string excludeProperties = "FirstName,Age";
        var dictionary = new Dictionary<string, Object>();
        person.GetType().GetProperties()
              .Where(x => !excludeProperties.Split(',').Contains(x.Name)).ToList()
              .ForEach(p =>
              {
                  var key = p.Name;
                  var value = p.GetValue(person);
                  dictionary.Add(key, value);
              });
        return dictionary;
    }
