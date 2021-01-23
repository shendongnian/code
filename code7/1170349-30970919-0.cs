    //	Serialize and write to file
    Person person = myPerson;
    var serializer = new XmlSerializer(person.GetType());
    using (var writer = XmlWriter.Create("person1.xml"))
    {
        serializer.Serialize(writer, person);
    }
    
    //	Deserialize back to an instance
    var serializer = new XmlSerializer(typeof(Person));
    using (var reader = XmlReader.Create("person1.xml"))
    {
        var person= (Person)serializer.Deserialize(reader);
    }
