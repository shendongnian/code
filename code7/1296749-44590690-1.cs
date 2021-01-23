     public Person FindPersonByName(string name)
     {
         return _collection.AsQueryable().FirstOrDefault(
                   personObject => personObject.Element.Name == name).Unwrap();
     }
