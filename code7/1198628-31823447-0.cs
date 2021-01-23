	void Main()
	{
			WelcomeMessage();
			ProgramLoop();
	}
    static void ProgramLoop()
	{
        bool startAgain = true;
        
		while (startAgain)
		{
			int litres = InputLitres();
			int kms = InputKM(litres);
			double consumption = consumptionCalculation(litres, kms);
			PrintResults(consumption);
			startAgain = DoItAgain();
		}
    }
	
	static bool DoItAgain()
    {
        Console.Write("Start Over? (Y or N):  ");
        string reply = Console.ReadLine();
        reply = reply.ToUpper();
        return reply.ToUpper() == "Y";
    }
    static void WelcomeMessage()
	{
        Console.WriteLine("\n\n\tWelcome to the Fuel Consumption Calculator\n\n\t");
    }
    static int InputLitres()
	{
		int selection = -1;
        int minLitres = 20;
        bool invalid = true;
        while (invalid)
		{
            Console.Write("\nEnter the amount of litres consumed:  ");
            if (int.TryParse(Console.ReadLine(), out selection))
			{
				invalid = selection < minLitres;
                if (invalid)
				{
                    Console.Write("\nPlease Enter an amount 20 litres or above\n\n Please Try Again:\n");
                }
			}
        }
		return selection;
    }
	
	static int InputKM(int litres)
	{
		int selection = -1;
		int minKms = 8 * litres;
        bool invalid = true;
        while (invalid)
		{
            Console.Write("\nEnter Kilometres Travelled: ");
            if (int.TryParse(Console.ReadLine(), out selection))
			{
				invalid = selection < minKms;
                if (invalid)
				{
                    Console.WriteLine("\nMinimum Kms is {0:f2} Kilometres, Please Enter a value of {0:f2} or higher", minKms);
                }
			}
        }
		return selection;
    }
    static double consumptionCalculation(int litres, int kms)
	{
        return (double)litres * 100.0 / (double)kms;
    }
    static void PrintResults(double consumption)
	{
        Console.WriteLine("\n\n\tYour Fuel Consumption is {0} Litres per 100 Kilometres", consumption);
    }
