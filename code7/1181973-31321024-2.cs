    static void Main(string[] args)
    {
        bool userWantsToStay = true;
        var conversions = new Dictionary<string, double>
        {
            { "Bronze", 10.0 },
            { "Silver", 10.5 },
            { "14k Gold", 13.5 },
            { "18k Gold", 15.0 },
            { "22k Gold", 17.3 },
            { "Platinum", 21.5 }
        };
        while (userWantsToStay)
        {
            Console.WriteLine("Please specify the type of conversion you would like to accomplish:");
            Console.WriteLine("(Bronze, Silver, 14k Gold, 18k Gold, 22k Gold, Platinum, or Exit):");
            var metalType = Console.ReadLine();
            Console.WriteLine("What is the weight of the wax model?");
            var wW = Console.ReadLine();
            var waxWeight = double.Parse(wW);
            if (conversions.ContainsKey(metalType))
            {
                var metalWeight = waxWeight * conversions[metalType];
                Console.WriteLine("You need {0} grams of {1}.", metalWeight, metalType.ToLower());
                Console.ReadLine();
            }
            else if (metalType == "Exit")
            {
                userWantsToStay = false;
            }
            else
            {
                Console.WriteLine("Sorry! That was an invalid option! Try again");
                Console.ReadLine();
            }
        }
    }
