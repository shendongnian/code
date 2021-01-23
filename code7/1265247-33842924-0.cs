    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication8
    {
        class Program
        {
            delegate int restriction(int x, string methodName);
    
            static void Main(string[] args)
            {
                int x = MethodOne(6);
                Console.WriteLine(x);
    
                int x1 = MethodOne(4);
                Console.WriteLine(x1);
    
                int x2 = Methodtwo(6);
                Console.WriteLine(x2);
    
                int x3 = Methodtwo(4);
                Console.WriteLine(x3);
    
    
    
                Console.ReadLine();
            }
    
            public static int restrictionMethod(int param, string methodName)
            {
                if (param > 5)
                {
                    param = 0;              
                    
                }
                if (methodName == "MethodOne")
                {
                    return param;
                }
                else if (methodName == "Methodtwo")
                {
                    return param * 4;
                }
    
                return -1;
            }
    
            public static int MethodOne(int param) 
           {
               restriction rx = restrictionMethod;
               int returnValue = rx(param, "MethodOne");
               return returnValue;
           }
    
            public static int Methodtwo(int param)
           {
               restriction rx = restrictionMethod;
               int returnValue = rx(param, "Methodtwo");
            
               return returnValue;
           }
       
    
        }
    }
