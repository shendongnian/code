        namespace MyNameSpace {
           public interface IMyClass
            {
                string Name { get; }
            }
           internal class MyClass : IMyClass  {
              public string Name { get; internal set; }
           }
           class NewMyClass {
       
               private IMyClass Init(string name)
               {
                   MyClass cls = new MyClass();
                   cls.Name = name;
                   return cls;
               }
             public List<IMyClass> method()
               {
                  var collection = new List<IMyClass>();
         
                  collection.Add(Init("1st Sample"));
                  collection.Add(Init("2nd Sample"));
                  return collection;
               }
           } 
        }
        namespace UserNameSpace
        {
            public class Prog
            {
                public static void Func()
                {
                    NewMyClass myC = new NewMyClass();
                    List<IMyClass> myList = myC.method();
                    foreach (IMyClass a in myList)
                    {
                        Console.WriteLine(a.Name);
                    }
                }
            }
        }
