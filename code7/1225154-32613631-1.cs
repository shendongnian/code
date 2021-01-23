    static void Main(string[] args)
    {
        try
        {
            int seedValue = -1;  //Or some other particular number. 
            if (args.Length > 0 && Convert.ToInt32(args[0]) > 0)
            {                
                    seedValue = Convert.ToInt32(args[0]);
            }
            else
            {
                Console.WriteLine("Please, use an integer greater than 0.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please, use an integer greater than 0:");
        }
    }
