    public class Dog
    {
        public Dog(int age)
        {
            this.Age = age;
        }
    
        [JsonProperty(Required = Required.Always)]
        public int Age { get; }
    }
