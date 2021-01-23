    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Person> people = new List<Person>();
                var boy = new Person() {name="John"};
                var girl = new Person() {name="Fonda"};
                var son = new Person() {name="Donald"};
                var other = new Person() {name="Mike"};
                var  other2 = new Person(){name="Roger"};
                people.AddRange(new Person[] { boy, girl, son, other, other2 });
                string str = "My name is John, her name is Fonda and his name is Donald";
                string[] peopleInSentenance = people.Where(x => str.Contains(x.name)).Select(y => y.name).ToArray();
           }
     
        }
        public class Person
        {
            public string name { get; set; }
        }
    }
