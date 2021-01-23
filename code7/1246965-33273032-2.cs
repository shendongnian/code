Assuming 6 sided dice, a Dictionary might be a good option.
    var rolls = new Dictionary<int, int> { {1,0}, {2,0}, {3,0}, {4,0}, {5,0}, {6,0} };
    for(int i = 0; i < 50; i++)
    {
       var first = Random.Next(1, 7);
       var second = Random.Next(1, 7);
       rolls[first]++;
       rolls[second]++;
       // Rest of rolling display code
    }
    // Header display code
    for(int i = 1; i <= 6; i++)
    {
         Console.Write("{0}: ", i);
         for(int j = 0; j < rolls[i].Value; j++)
         {
             Console.Write("|");
         }
         Console.WriteLine();
    }
