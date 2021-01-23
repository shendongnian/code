    var Person = new List<Person>();
    Person a = new Person("Umer", 25);
    Person b = new Person("Faisal", 24);
    Person.Add(a);
    Person.Add(b);
    var collection = Person;
    dynamic collectionWrapper = new {
      myRoot = collection
    };
    var output = JsonConvert.SerializeObject(collectionWrapper);
