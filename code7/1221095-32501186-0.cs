    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        class Person
        {
            private readonly string name;
            private readonly int    age;
            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            public string getName()
            {
                return name;
            }
            public int getAge()
            {
                return age;
            }
        }
        internal class Program
        {
            private static void Main(string[] args)
            {
                var persons = new List<Person>
                {
                    new Person("C", 4),
                    new Person("D", 1),
                    new Person("A", 3),
                    new Person("B", 2)
                };
                persons.Sort((a,b) => a.getName().CompareTo(b.getName()));
                print(persons); // Ordered by name "A", "B", "C", "D".
                persons.Sort((a, b) => a.getAge().CompareTo(b.getAge()));
                print(persons);  // Ordered by age "1", "2", "3", "4".
            }
            private static void print(List<Person> persons)
            {
                foreach (var person in persons)
                    Console.WriteLine("Name: {0}, Age: {1}", person.getName(), person.getAge());
                Console.WriteLine();
            }
        }
    }
