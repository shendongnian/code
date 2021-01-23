    void Main()
    {
        int numbWrong = 0;
        int maxAttempts = 10;
    
        string myWord = "example";
        string dashed = "-------";
        char[] dashedArray = dashed.ToCharArray();      
        
        for (int attempts = 0; attempts < maxAttempts; attempts++)
        {
            Console.WriteLine("Enter your guess letter using lowercase only.\n");
            char input = Console.ReadLine()[0];
            
            if (!myWord.Contains(input))
            {
                numbWrong++;
                continue;
            }
            for (int i = 0; i < myWord.Length; i++)
            {
                if (myWord[i] == input)
                {
                    dashedArray[i] = input; 
                }
            }
    
            Console.WriteLine (new string(dashedArray));
            if(!dashedArray.Contains('-'))break;
        }
        
        Console.WriteLine ("Wrong: {0}", numbWrong);
    }
