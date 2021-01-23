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
                student.students = new List<student>() {
                    new student() { Name = "david", age = 22,  address = "asfdsdfs"},
                    new student() { Name = "rogers", age = 20,  address = "zczxc"},
                    new student() { Name = "richard", age = 17,  address = "gfhghfg"}
                };
                List<student> query = student.students.Where(x => x.Name == "david").ToList();
            }
        }
        public class student
        {
            public static List<student> students {get; set;}
            public string Name{get;set;}
            public int age{get;set;}
            public string address{get;set;}
            public string property {get;set;}
        }
    }
