    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StackQuestionAnswersCS
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (checkContains("HelloWorld", 'o')) Console.WriteLine("Contains Character");
                else Console.WriteLine("Does not contain character");
                Console.ReadLine();
            }
    
            static bool checkContains(string input, char character)
            {
                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (input[i] == character && input[i+1] == character) return true;
                }
                return false;
            }
        }
    }
