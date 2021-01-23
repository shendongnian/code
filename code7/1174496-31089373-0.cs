    class Program
    {
        class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public Person(int id, string name)
            {
                this.ID = id;
                this.Name = name;
            }
        }
        static void Main(string[] args)
        {
            Person person1 = new Person(1, "name1");
            Person person2 = new Person(2, "name2");
            List<Person> items = new List<Person>();
            items.Add(person1);
            items.Add(person2);
            Console.WriteLine(string.Format("Person 1...{0}, {1}", person1.ID, person1.Name));
            Console.WriteLine(string.Format("Person 2...{0}, {1}", person2.ID, person2.Name));
            foreach (Person p in items)
                Console.WriteLine(string.Format("Person from list...{0}, {1}", p.ID, p.Name));
            person1.Name = "name1 after";
            person2.Name = "name2 after";
            Console.WriteLine(string.Format("Person 1 after...{0}, {1}", person1.ID, person1.Name));
            Console.WriteLine(string.Format("Person 2 after...{0}, {1}", person2.ID, person2.Name));
            foreach (Person p in items)
                Console.WriteLine(string.Format("Person from list after...{0}, {1}", p.ID, p.Name));
            Console.ReadKey();
        }
    }
