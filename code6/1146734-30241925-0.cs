    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication29
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Person> personList = new List<Person>();
                string[] groups = { "Forename", "Surname" };
                var grouped = personList.GroupBy(x => new object[] { Grouper(x, groups) })
                            .Select(x => new { Description = x.Key, Count = x.Count() });
            }
            static object[] Grouper(Person person, string[] groups)
            {
                List<object> results = new List<object>();
                foreach (string group in groups)
                {
                    switch (group)
                    {
                        case "Forename" :
                            results.Add(person.Forename);
                            break;
                        case "Surnamename":
                            results.Add(person.Surname);
                            break;
                        case "Age":
                            results.Add(person.Age);
                            break;
                        case "Gender":
                            results.Add(person.Gender);
                            break;
                    }
                }
                return results.ToArray();
            }
        }
        public class Person
        {
            public string Forename { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
        }
    }
