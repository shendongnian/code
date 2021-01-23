    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                while (true)
                {
                    int mainMenuOption = OptionMenu("Instructions", "New User", "Record & Score", "Exit System");
                    switch (mainMenuOption)
                    {
                        case 1: Instructions(); break;
                        case 2: NewUser(); break;
                        case 3: RecordAndScore(); break;
                        case 4: Console.WriteLine("Goodbye.."); return;
                    }
                }
    
            }
    
            static void Instructions()
            {
                // Handle Instructions here
                Console.WriteLine("Instrucctions done");
            }
    
            static void NewUser()
            {
                // Handle New User here
                Console.WriteLine("New user done");
            }
    
            static void RecordAndScore()
            {
                // handle recorde and score here
                Console.WriteLine("Record & score done");
            }
    
    
            static int OptionMenu(params string[] optionLabels)
            {
                Console.WriteLine("Please Choose an option");
                for (int optionIndex = 0; optionIndex < optionLabels.Length; optionIndex++)
                {
                    Console.Write(optionIndex + 1);
                    Console.Write(".- ");
                    Console.WriteLine(optionLabels[optionIndex]);
                }
                while (true)
                {
                    var input = Console.ReadLine();
                    int selectedOption;
                    if (int.TryParse(input, out selectedOption) && selectedOption > 0 && selectedOption <= optionLabels.Length)
                    {
                        return selectedOption;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option, please try again");
                    }
                }
            }
        }
    }
