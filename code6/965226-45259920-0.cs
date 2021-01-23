    static void Main(string[] args)
        {
            int intUserInput = 0;
            bool validUserInput = false;
            while (validUserInput == false)
            {
                try
                { Console.Write("Please enter an integer value greater than or equal to 1: ");
                  intUserInput = int.Parse(Console.ReadLine()); //try to parse the user input to an int variable
                }  
                catch (Exception) { } //catch exception for invalid input.
                if (intUserInput >= 1) //check to see that the user entered int >= 1
                  { validUserInput = true; }
                else { Console.WriteLine("Invalid input. "); }
            }//end while
            Console.WriteLine("You entered " + intUserInput);
            Console.WriteLine("Press any key to exit ");
            Console.ReadKey();
        }//end main
