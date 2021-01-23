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
                List<HumanA> aS = new List<HumanA>();
                List<HumanB> bS = aS.Select(x => new HumanB() { name = x.name, lastName = x.lastName, age = x.age }).ToList(); 
            }
        }
        public class IHuman
        {
            public string name { get; set; }
            public string lastName { get ;set; }
            public int age { get; set; }
        }
        public class HumanA : IHuman
        {
        //Implementation
        }
        public class HumanB : IHuman
        {
           //Implementation
        }
    }
    ​
