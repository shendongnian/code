    class Program
    {
        static List<Animal> animals = new List<Animal>();
    
        static void Main(string[] args)
        {
            animals.Add(new Animal() { Age = 3, Name = "Terry", Type = "Tiger" });
            animals.Add(new Animal() { Age = 1, Name = "Bob", Type = "Badger" });
            animals.Add(new Animal() { Age = 7, Name = "Alfie", Type = "Dog" });
    
            GetList("Age").ForEach(Console.WriteLine);
    
            Console.Read();
        }
    
        public static List<string> GetList(string property)
        {
            return animals.Select(o => o.GetType().GetProperty(property).GetValue(o).ToString()).ToList();
        }
    }
    
    class Animal
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
    }
