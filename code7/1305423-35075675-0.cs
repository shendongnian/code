    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TestApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                decimal demo1 = 1.2311M;
                decimal demo2 = 1.2300M;
                decimal demo3 = 1.00M;
                decimal demo4 = 1M;
    
                if (IsValid(demo1))
                {
                    Console.WriteLine(ValueKeptZero(demo1));
                }
    
                if (IsValid(demo2))
                {
                    Console.WriteLine(ValueKeptZero(demo2));
                }
    
                if (IsValid(demo3))
                {
                    Console.WriteLine(ValueKeptZero(demo3));
                }
    
                if (IsValid(demo4))
                {
                    Console.WriteLine(ValueKeptZero(demo4));
                }
    
                Console.ReadLine();
            }
    
            static bool IsValid(object value)
            {
    
                if (!(value.GetType() == typeof(decimal)))
                    return false;
    
                decimal tmp = (decimal)value;
    
                if(tmp == 1.23M)
                {
                    string test = tmp.ToString();
    
                    if(test.Substring(test.IndexOf(".") + 1).Length != 4)
                    {
                        return false;
                    }
    
                }
    
                return true;
    
            }
    
            static decimal ValueKeptZero(object value)
            {
                return (decimal)value;
            }
    
        }
    }
