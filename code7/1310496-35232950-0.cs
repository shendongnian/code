    using system;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    namespace AtoZRecursion
    { 
        class Program
        {  
            static void Main(string[] args)
            {
                int number=65;
                getAplha(number);
            
                Console.ReadKey();
            }
            public static int getAplha(int number=65)
            {
                if (number==90)
                {
                    Console.WriteLine(Convert.ToChar(number));
                    return Convert.ToChar(number);
                }
                Console.WriteLine(Convert.ToChar(number));
                return Convert.ToChar(getAplha(number + 1));
            }
        }
    }
