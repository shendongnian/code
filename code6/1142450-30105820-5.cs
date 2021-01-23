    class Program
    {
        static void DisplayArray(params int[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.Write("{0}\t", args[i]);
            }
            Console.Write("\n");
        }
        static void Main(string[] args)
        {
            //static array for winning[6], empty for player[6], empty for matching[6]
            int [] winning = new int [6] {2, 4, 6, 9, 1, 3};
            string[] tmp = new string[6];
            int [] player = new int [6];
            int [] matching = new int [6];
            string line;
            int inValue;
            bool valid;
            //Input loop
            do
            {
                Console.WriteLine("Please enter six lotto numbers between 1 and 9, separated by spaces: ");
                valid = true;
                line = Console.ReadLine();
                tmp = line.Split(' '); //split on space
                for (int i = 0; i < tmp.Length; i++)
                {
                    int.TryParse(tmp[i], out inValue);
                    if (inValue < 1 || inValue > 9) //Validate for int 1-9
                    {
                        Console.WriteLine("{0} must be a whole number between 1 and 9", tmp[i]);
                        valid = false;
                    }
                    player[i] = inValue;
                }
            }
            while (!valid);
            //Output
            Console.WriteLine("The winning numbers were:");
            DisplayArray(winning);
            Console.WriteLine("Your numbers were:");
            DisplayArray(player);
            //Console.WriteLine("You had " + MatchCount() + " matches.");
            //Console.WriteLine("Your matching numbers are:")
            //DisplayArrayContents(matching);
            //Console.Read();
            string retVal = "";
            while(retVal != "exit")
            {
                Console.WriteLine("Type 'exit' to end the program: ");
                retVal = Console.ReadLine();
                if (retVal == "exit")
                    Environment.Exit(0);
            }
        }
    }
