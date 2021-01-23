    using System.IO;
    using System;
    using System.Linq;
    
    
    public class Program
    {
        
        public class Dog
       {
       
        public static string Name {get;set;}
        public static string Race {get;set;}
       }
       
        public static bool validate(Dog dog)
        {
            bool val = true;
            var y  = dog.GetType()
                        .GetProperties()
                        .Select(p =>
                            {
                                object value =p.GetValue(dog,null);
                                if(string.IsNullOrEmpty(value.ToString())){ val=false; return false;}
                                else return true;
                                
                            })
                        .ToArray();
               
             return val;
        }
    
        public static void Main()
        {
            Dog dog= new Dog();
            
            Dog.Name = "Peter";
            Dog.Race = "";
            
            if(validate(dog))
            {
                 Console.WriteLine("Hello, World!");
            }
           
           
        }
    }
