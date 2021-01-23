    List<Person> eList = new List<Person>();
    Person a = new Person("Umer", 25);
    Person b = new Person("Faisal", 24);
    eList.Add(a);
    eList.Add(b);
    string jsonString = JsonConvert.SerializeObject(eList,Formatting.Indented,
        new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
