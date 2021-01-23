    public class Animal
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    [DeserializeElementAs(Name = "object", Attribute = "type", Value = "cat")]
    [DeserializeAs(Name = "cat")]
    public class Cat : Animal
    {
    }
    [DeserializeElementAs(Name = "object", Attribute = "type", Value = "dog")]
    [DeserializeAs(Name = "dog")]
    public class Dog : Animal
    {
    }
