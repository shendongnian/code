    using System;
    
    namespace prac4b
    {
    class prac4b
    {
    
    
        static void Main(string[] args)
        {
            int number1, number2, result;
            char action;
            string tempVal = "";
    
            bool parseAttempt = false;
    
            // ask for first number
            Console.ReadLine();
            Console.Write("Enter number > ");
    
            //testing if integer with TryParse
            tempVal = Console.ReadLine();
            parseAttempt = Int32.TryParse(tempVal, out number1);
    
            // if not a number
            if (parseAttempt == false)
            {
                Console.WriteLine("You have not entered a number, application will now exit.");
                Environment.Exit(0);
    
            }
            //if true, continue, ask for number2
            if (parseAttempt == true)
            {
                //asking for number
                Console.Write("Enter another number > ");
                tempVal = Console.ReadLine(); //storing number temporailiy for checking
                parseAttempt = Int32.TryParse(tempVal, out number2); //checking number2 if integer
    
                //if not a number
                if (parseAttempt == false)
                {
                    Console.WriteLine("ERROR you have not entere a valid integer");
                    Environment.Exit(0);
                }
                //if true, continue, ask for action(+*-+)
                Console.WriteLine("Action (*/+-) > ");
                var readaction = Console.ReadLine();
                string actionString = readaction.ToString();
                switch (actionString) //switch statement for action list
                {
                    case "+":
                        Console.WriteLine("Result is > ", number1 + number2);
                        break;
                    case "-" :
                        Console.WriteLine("Result is > ", number1 - number2);
                        break;
                    case "*" :
                        Console.WriteLine("Result is > ", number1 * number2);
                        break;
                    case "/" :
                        Console.WriteLine("Result is > ", number1 / number1);
                        break;
                    default :
                        Console.WriteLine("ERROR INVALID INPUT");
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine();
            }
        }
    }
    }
