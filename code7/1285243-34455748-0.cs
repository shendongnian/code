    public class Person
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Age { get; private set; }
        public Person(int age)
        {
            Age = age;
        }
    }
