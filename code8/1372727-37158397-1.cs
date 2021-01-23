    class Person
    {
        public string Name { get; }
    }
    
    //Person.Name   -> invalid, "Name" property is not static
    //new Person().Name    -> valid, "Name" property is access via an instance of "Person"
