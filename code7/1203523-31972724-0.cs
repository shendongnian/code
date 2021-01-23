    public class Person
    {
        public string Name;
        public string LastName;
        public int Age;
    
        public Person()
        {
    
        }
        public Person(string name, string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} - {2} Years Old", Name, LastName, Age);
        }
    }
