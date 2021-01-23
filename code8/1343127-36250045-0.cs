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
                MyClass.data = new List<MyClass>() {
                    new MyClass() { ID = 1,  Name = "Item1",    ParentID = null},
                    new MyClass() { ID = 2,  Name = "Item2",    ParentID = 1 },
                    new MyClass() { ID = 3,  Name = "Item3",    ParentID = 2 },
                    new MyClass() { ID = 4,  Name = "Item4",    ParentID = 2 },
                    new MyClass() { ID = 5,  Name = "Item5",    ParentID = 3 }
                };
                MyClass myClass = new MyClass();
                myClass.GetData(null, 0);
                Console.ReadLine();
            }
        }
        public class MyClass
        {
            public static List<MyClass> data = null;
            public int ID { get; set; }
            public string Name { get; set; }
            public int? ParentID { get; set; }
            public void GetData(int? id, int level)
            {
                List<MyClass> children = data.Where(x => x.ParentID == id).ToList();
                foreach (MyClass child in children)
                {
                    Console.WriteLine(" {0} ID : {1}, Name : {2}, Parent ID : {3}", new string(' ',4 * level),child.ID, child.Name, child.ParentID);
                    GetData(child.ID, level + 1);
                }
            }
        }
    }
