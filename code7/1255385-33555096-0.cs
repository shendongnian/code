    public class Person {
            public string Name { get; set; }
            public string LastName { get; set; }
        }
    
        public class Test {
            public Test() {
                List<Person> persons = new List<Person>();
                persons.Add(new Person() { Name = "Person1",LastName = "LastName1" });
                persons.Add(new Person() { Name = "Person2",LastName = "LastName2" });
                var getNamesFromPersons = persons.Select(p => p.Name);
            }
        }
