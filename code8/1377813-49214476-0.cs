    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(Dog), "HadWalkToday")]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(Cat), "ColorOfWhiskers")]
    public class Animal
    {
        public string Name { get; set; }
    }
    
    public class Dog : Animal
    {
        public bool HadWalkToday { get; set; }
    }
    
    public class Cat : Animal
    {
        public string ColorOfWhiskers { get; set; }
    }
