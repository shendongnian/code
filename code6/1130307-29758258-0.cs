    int input = 0;
    string errorMessage = "Error: Please enter either 1, 2 or 3";
    while(true)
    {
        try
        {
            input = Convert.ToInt32(Console.ReadLine());
        
            if (input == 0 || input > 3)
            {
                Console.WriteLine(errorMessage);
            }
            else
            {
                break;
            }
        }
        catch(FormatException)
        {
             Console.WriteLine(errorMessage);
        }
    }
