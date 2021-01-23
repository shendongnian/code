    static void Main(string[] args)
    {
        int userinput = Convert.ToInt16(Console.ReadLine());
        Random Dice = new Random();
        int[] numberofdice = new int[userinput + 1];
    
        while(true)
        {
            var output = string.Empty;
    
            // Generate the userinput random numbers
            // as well as output string
            for(int i = 0; i < userinput; i++)
            {
                numberofdice[i] = Dice.Next(1, 7);
                output += numberofdice[i];
            }
            Console.WriteLine(output);
    
            // Check that they are all same by comparing with first
            bool same = true;
            int first = numberofdice[0];
            for(int i = 1; i < userinput; i++)
            {
                if(numberofdice[i] != first)
                {
                    same = false;
                    break;
                }
            }
    
            // If all were the same, stop.
            if(same)
                break;
        }
    }
