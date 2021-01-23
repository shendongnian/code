    public class Dog 
    {
        public string Name { get; set; }
     
        // DogCreationTime is immutable
        private readonly DateTime creTime;
        public DateTime DogCreationTime 
        {
            get { return creTime; }
        }
     
        public Dog(string name)
        {
            Name = name;
            creTime = DateTime.Now;
        }
    }
