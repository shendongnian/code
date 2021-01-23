    namespace MyNameSpace {
    
       public class MyClass {
    
           internal string Name { get; set; }
       }
       public class NewMyClass {
           MyClass cls = new MyClass();
           cls.Name = "My Name";
       } 
    } 
