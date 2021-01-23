    if (tollResponse == "yes")
    {
        Console.WriteLine("How much do you pay per trip?");
        //Loop over the Console.ReadLine() using the else statement and exit if it is right the first time
        do
        {
            string tollTax = Console.ReadLine();
            //toll.Success gets set here.
            Match toll = Regex.Match (tollTax, @"[\d .]+");
            if (toll.Success)
            {
                //Not sure why you are doing this since you aren't using it in the given code
                Math.Round(Convert.ToDecimal(tollTax), 2);
                Console.WriteLine("Good lord that's high... well it's your money");
                //will exit
            }
            else
            {
                Console.WriteLine("Please enter a proper number");
            } 
        } while (toll.Success == false);
    }
