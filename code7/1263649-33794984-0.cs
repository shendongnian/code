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
                List<Dog> Dogs = new List<Dog>();
                List<Cat> Cats = new List<Cat>();
                object q;
                int petType = 1;
                
                switch(petType)
                {
                case 1:
                    q = from c in Cats
                                where c.Type == 1
                                select c;
                     break;
                case 2:
                    q = from d in Dogs 
                                where d.Type == 1
                                select d; 
                     break;
                 }
            }
        }
        public class Cat
        {
            public int Type { get; set; }
        }
        public class Dog
        {
            public int Type { get; set; }
        }
    }
    ​
