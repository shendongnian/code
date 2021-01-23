    int size = 64;    // The number of random numbers generators
    int length = 20;  // The number of random numbers from each generator
    int steps = 18;   // Move 18 steps forward in the beginning to show a particular phenomenon
    Random[] r = new Random[size];
    for (int i = 0; i < size; i++)
    {
         r[i] = new Random(i + 1);
         // move RNG forward 18 steps
         for (int j = 0; j < steps; j++)
         {
              r[i].Next(3);
         }
    }
    for (int i = 0; i < size; i++)
    {
         for (int j = 0; j < length; j++)
         {
              Console.Write(r[i].Next(3) + ", ");  // Generate a random number, 0 represents a small number, 1 a medium number and 2 a large number
         }
         Console.WriteLine();
    }
