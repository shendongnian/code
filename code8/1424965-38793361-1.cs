      var key = new PersonKey(person.ZipCode, person.LastName, person.FirstName);
      List<Person> lst;
      foreach (var possKey in key.AllPossibleKeys) {
          var k = key.MakeKey(possKey);
          if (!_lookup.TryGetValue(k, out lst)) {
               lst = new List<Person>();
               _lookup.Add(k, lst);
          }
          lst.Add(person);
       }
