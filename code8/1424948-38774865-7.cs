    Person person = new Person { /* Set members here */ }
    // Note that I'll add many keys that have the same value
    dict.Add(new CompositeKey { Name = "Matías" }, person );
    dict.Add(new CompositeKey { LastName = "Fidemraizer" }, person);
    dict.Add(new CompositeKey { Name = "Matías", LastName = "Fidemraizer" }, person);
