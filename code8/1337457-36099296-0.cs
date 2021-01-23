       public class Citizen
        {
            public static List<Person> personList = new List<Person>() {
                new Person{Name="Person1"},
                new Person{Name="Person2"},
                new Person{Name="Person3"},
                new Person{Name="Person4"}
            };
        }
        public class Person
        {
         public string Name {get;set;}
         public string Address {get; set;}
         public string DOB {get; set;}
        }
