    string[] subProperties1 = new string[] { "1", "2", "3" };
    string[] subProperties2 = new string[] { "4", "5", "6" };
    Person person = new Person { Name = "Johny", Age = 7 };
    person.Bars = new Bars { 
        items = subProperties1.Zip(subProperties2, 
                                    (prop1, prop2) => new Item { Sub_Property1 = prop1, Sub_Property2 = prop2 })
                                .ToArray() };
    var json = JsonConvert.SerializeObject(person);
