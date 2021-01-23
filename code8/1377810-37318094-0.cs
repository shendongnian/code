    [DataContract]
    [KnownType(typeof(Dog))] // add these
    [KnownType(typeof(Cat))] // lines
    public class Animal
    {
        [DataMember]
        public string Name { get; set; }
    }
    [DataContract]
    public class Dog : Animal
    {
    }
    [DataContract]
    public class Cat : Animal
    {
    }
