    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        public class MyClass1
        {
            public int id;
            public string Name;
    
            public override string ToString()
            {
                return "id = \"" + id + "\", Name=\"" + Name + "\"";
            }
        }
    
        public class SomeCustomClass
        {
            public int MaterialId { get; set; }
            public string CwNumber { get; set; }
            public string MaterialName { get; set; }
            public List<MyClass1> ListMyClass { get; set; }
    
            public SomeCustomClass()
            {
                ListMyClass = new List<MyClass1>();
            }
    
            public static string operator -(SomeCustomClass b, SomeCustomClass c)
            {
                string commonIDsDifferentNames = "";
                string uniqueIDs = "";
                List<int> usedInC = new List<int>();
                
                int cCount = 0;
                foreach (MyClass1 element in b.ListMyClass)
                {
                    cCount = 0;
                    bool found = false;
                    foreach (MyClass1 element2 in c.ListMyClass)
                    {
                        if (element.id == element2.id)
                        {
                            found = true;
                            usedInC.Add(cCount);
    
                            if(element.Name == element2.Name)
                                break;
    
                            commonIDsDifferentNames += element + " : " + element2;
                        }
                        cCount++;
                    }
    
                    if(!found)
                    {
                        uniqueIDs += element + " : id=\"\", Name=\"\"";
                    }
    
                }
    
                cCount = -1;
                foreach (MyClass1 element2 in c.ListMyClass)
                {
                    cCount++;
                    if (usedInC.Contains(cCount))
                        continue;
    
                    uniqueIDs += "id=\"\", Name=\"\" : " + element2;
                }
    
                return commonIDsDifferentNames + " | " + uniqueIDs;
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                SomeCustomClass a = new SomeCustomClass();
                SomeCustomClass b = new SomeCustomClass();
                a.CwNumber = "A";
                a.MaterialId = 1;
                a.MaterialName = "Material1";
                a.ListMyClass.Add(new MyClass1 { id = 11, Name = "John" });
                a.ListMyClass.Add(new MyClass1 { id = 12, Name = "Naren" });
    
                b.CwNumber = "A";
                b.MaterialId = 2;
                b.MaterialName = "Material2";
                b.ListMyClass.Add(new MyClass1 { id = 11, Name = "Tamsan" });
                b.ListMyClass.Add(new MyClass1 { id = 12, Name = "Naren" });
                b.ListMyClass.Add(new MyClass1 { id = 13, Name = "sanjy" });
    
                Console.WriteLine(a - b);
                Console.ReadKey();
            }
        }
    }
