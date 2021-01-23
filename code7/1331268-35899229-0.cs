            Console.WriteLine("\nGPA Score: ");
            string userinput2 = Console.ReadLine();
            decimal Result = 0;
            
            bool TGPA = decimal.TryParse(userinput2, out Result);
            while (TGPA == false)
            {
                Console.WriteLine("{0} is not a valid number, please try again", userinput2);
                userinput2 = Console.ReadLine();
                Result = 0;
                TGPA = decimal.TryParse(userinput2, out Result);
            }
