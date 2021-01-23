    var json = new List<PeopleList>();
    List<Person> p1 = new List<Person> { new Person { name = "Name 1", age = 20 } };
    json.Add(new PeopleList { inputs = p1 });
    List<Person> p2 = new List<Person> { new Person { name = "Name 2", age = 30 } };
    json.Add(new PeopleList { inputs = p2 });
    string jsonString = JsonConvert.SerializeObject(json, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });
