Assuming 6 sided dice, a Dictionary might be a good option.
    var rolls = new SortedDictionary<int, int> { {1,0}, {2,0}, {3,0}, {4,0}, {5,0}, {6,0} };
    for(int i = 0; i < 50; i++)
    {
       var first = Random.Next(1, 7);
       var second = Random.Next(1, 7);
       rolls[first]++;
       rolls[second]++;
       // Rest of rolling display code
    }
    // Header display code
    foreach(var roll in rolls)
    {
         Console.Write("{0}: ", roll.Key);
         for(int i = 0; i < rolls.Value; i++)
         {
             Console.Write("|");
         }
         Console.WriteLine();
    }
