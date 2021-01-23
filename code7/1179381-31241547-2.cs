    var criteria = new GenericCriteria<Person>();
    criteria.List.Add( q => q.Where( c => c.Age > 20) );
    criteria.List.Add( q => q.OrderBy( c => c.Age ));
    
    var persons = Data.Instance.GetPersons(criteria);
