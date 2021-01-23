    Person person = new Person { /* Set members here */ }
    // Note that I'll add many keys that have the same value
    dict.Add(new CompositeKey(name: "Matías"), person);
    dict.Add(new CompositeKey(lastName: "Fidemraizer"), person);
    dict.Add(new CompositeKey(firstName: "Matías", lastName: "Fidemraizer"), person);
