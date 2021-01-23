    public static void Main(string[] args)
    {
         int[] gameScores = Enumerable.Range(1, 10).ToArray();
         Console.WriteLine("Please enter an index between 0 and {0}", gameScores.Length - 1);
         int selectedIndex = Convert.ToInt32(Console.ReadLine());
         if(selectedIndex >= 0 && selectedIndex < gameScores.Length)
              for(int i = 0; i < gameScores.Length; i++)
                   gameScores[i] = Convert.ToInt32(Console.ReadLine());
         else
             Console.WriteLine("No such score exists");
    }
