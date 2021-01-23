    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; } // Note: Age is an int, and will result in "Age": 30
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    List<Person> testData = new List<Person>();
    testData.Add(new Person("John", 30));
    testData.Add(new Person("Doe", 36));
    JsonConvert.SerializeObject(testData);
