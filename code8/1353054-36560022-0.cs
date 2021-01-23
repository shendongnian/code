    class Program
    {
        static void Main(string[] args)
        {
            Dog d = new Dog { Age = 37, Name = "Nick" };
            Tiger t = d.ConvertTo<Dog, Tiger>();
            Debug.Assert(t.Name == d.Name);
            Debug.Assert(t.Age == d.Age);
        }
    }
    static class AnimalExtension
    {
        public static TOut ConvertTo<TIn, TOut>(this TIn animal) 
            where TIn : IAnimal 
            where TOut : IAnimal, new()
        {
            TOut convertedAnimal = new TOut
            {
                Age = animal.Age,
                Name = animal.Name
            };
            return convertedAnimal;
        }
    }
    interface IAnimal
    {
        string Name { get; set; }
        int Age { get; set; }
    }
    class Tiger : IAnimal
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    class Dog : IAnimal
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
