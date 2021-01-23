    namespace Behave
    {
        using System;
        using System.Reflection;
    
        public class CheckHolidayAttribute : Attribute { }
    
        class Program
        {
            static void Main(string[] args)
            {
                SomeAction();
                Console.Read();
            }
    
            //[CheckHoliday] // uncomment this to see what happens
            public static void SomeAction()
            {
                if(MethodInfo.GetCurrentMethod().GetCustomAttribute<CheckHolidayAttribute>() != null)
                {
                    Console.WriteLine("Has attr");
                }
                else
                {
                    Console.WriteLine("Does not have attr");
                }
            }
        }
    }
