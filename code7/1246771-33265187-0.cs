    public int[] Scores()
        {
        int[] score = new int[amountgames];
        Console.WriteLine("score for game ");
        for (int i = 0; i < score.Length; i++)
        {
        score[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("\nThe scores you entered are");
         for (int j = 0; j < score.Length; j++)
            {
        Console.WriteLine(score[j]);
            }
        } 
        return score;
    }
