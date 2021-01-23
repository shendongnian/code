    var nameListCopy = nameList.Select(n => new Names
    {
        Property1 = n.Property1,
        Property2 = n.Property2,
        // ... the rest of the properties
    }).ToList();
    using (Form2 fm2 = new Form2(nameListCopy))
    // ...
