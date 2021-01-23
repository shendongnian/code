    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace sequence
    {
        class Program
        {
            static void Main(string[] args)
            {
                int userInput = Console.Read();
    
                Console.WriteLine("User input is: {0}", userInput.GetType());
                Console.WriteLine("User input is: {0}", userInput - 48);
            }
        }
    }
