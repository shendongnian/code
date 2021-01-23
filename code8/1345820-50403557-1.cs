    [ProtoContract]
    class Person {
        [ProtoMember(1)]
        public int Id {get;set;}
        [ProtoMember(2)]
        public string Name {get;set;}
    }
    Serializer.Serialize(file, person);
    newPerson = Serializer.Deserialize<Person>(file);
