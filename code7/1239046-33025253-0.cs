     private static bool CheckWhetherInteger(string userInput)
    {
        if (userInput == "0")
        {
           myInteger = 0;
           return true 
        }
        else
        {
            bool result = Int32.TryParse(userInput, out myInteger);
            if (result == false)
                {
                Console.Clear();
                Console.WriteLine("You did not enter an integer.");
            }
        }
        return result;
    }
