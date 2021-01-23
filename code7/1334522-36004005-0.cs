            int variable1, variable2, variable3, sum, reminder;
            double average;
            string variable11, variable21, variable31;
            Console.Write("Enter a number:");
            variable11 = Console.ReadLine();
            Console.Write("Enter another number:");
            variable21 = Console.ReadLine();
            Console.Write("one more:");
            variable31 = Console.ReadLine();
            // Now you have three variables in your hand 
            // You can play with them as you wish
            //Converting each them to an integer 
            if (!Int32.TryParse(variable11, out variable1))
            {
                Console.WriteLine("Show error ; Conversion failed");
            }
            if (!Int32.TryParse(variable21, out variable2))
            {
                  Console.WriteLine("Show error ; Conversion failed");
            }
            if (!Int32.TryParse(variable31, out variable3))
            {
                Console.WriteLine("Show error ; Conversion failed");
            }
            //Performing operations:
            sum = variable1 + variable2 + variable3;
            average =(double)sum / 3;
            reminder = sum % 3;
            //Formating the Output:
            Console.WriteLine("The Operation Result");
            Console.WriteLine("The Sum of {0},{1},{2} is {3} , AVERAGE is{4} and Reminder is {5}",variable1,variable2,variable3,sum,average,reminder );
            Console.ReadKey();
