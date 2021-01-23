    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
        class Program
        {
    
            public decimal GetPrice(decimal price)
            {
                return price;
            }
    
            public decimal GetPrice(decimal price, int qty)
            {
                return price * qty;
            }
    
            public decimal GetPrice(decimal price, int qty, decimal tax)
            {
                return price * qty * tax;
            }
    
            static void Main(string[] args)
            {
    
            }
        }
    }
