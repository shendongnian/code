    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    
    namespace SandboxConsole
    {
        internal class Program
        {
            public static void Main()
            {
                var bob = new Person {Id = 0};
                var scott = new Person {Id = 1};
                var dave = new Person {Id = 2};
    
                bob.Friends.Add(scott);
                bob.Friends.Add(dave);
                scott.Friends.Add(dave);
    
                var people = new List<Person>();
                people.Add(bob);
                people.Add(scott);
                people.Add(dave);
    
                using (var fs = File.OpenWrite("Test.xml"))
                {
                    var ser = new DataContractSerializer(typeof(List<Person>));
                    ser.WriteObject(fs, people);
                }
    
                List<Person> people2;
                using (var fs = File.OpenRead("Test.xml"))
                {
                    var ser = new DataContractSerializer(typeof(List<Person>));
                    people2 = (List<Person>)ser.ReadObject(fs);
                }
    
                Console.WriteLine("Are these daves the same dave?");
                Console.WriteLine("List dave, bob's friend - {0}", ReferenceEquals(people2[2], people2[0].Friends[1]));
                Console.WriteLine("Bob's firend, scott's friend - {0}", ReferenceEquals(people2[0].Friends[1], people2[1].Friends[0]));
                Console.ReadLine();
            }
        }
    
        [DataContract(IsReference = true)]
        public class Person
        {
            public Person()
            {
                Friends = new List<Person>();
            }
    
            [DataMember]
            public int Id { get; set; }
    
            [DataMember]
            public List<Person> Friends { get; private set; }
        }
    }
