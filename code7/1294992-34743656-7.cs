    public class Dog
    {
        public string Name { get; set; }
     
        // DogCreationTime is immutable
        public DateTime DogCreationTime { get; } = DateTime.Now;
     
        public Dog(string name)
        {
            Name = name;
        }
    }
