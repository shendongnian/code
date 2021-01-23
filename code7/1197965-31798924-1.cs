    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                char arithmeticOperator;
                bool decision = false;
                while (decision == false)
                {
                    Console.Write("Choose an Operator (+ - * /) : ");
                    char.TryParse(Console.ReadLine(), out arithmeticOperator);
                    switch (arithmeticOperator)
                    {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            decision = true;
                            break;
                        default:
                            decision = false;
                            break;
                    }
                
                    if (decision == false)
                    {
                        Console.WriteLine("Not an Operator, try again...");
                    }
                }
            }
        }
    }
