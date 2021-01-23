    class Cheese
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Taste { get; set; }
        public Dictionary<String, Producer> Producers { get; set; }
        public Cheese()
        {
            Producers = new Dictionary<String, Producer>();
        }
        public Cheese(string name, int age)
        {
            Name = name;
            Age = age;
            Producers = new List<Producer>();
        }
        public Cheese(string name, int age, string taste)
        {
            Name = name;
            Age = age;
            Taste = taste;
            Producers = new List<Producer>();
        }
    }
    
