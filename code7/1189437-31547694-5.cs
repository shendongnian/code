    int[,] array = 
    {
        { 1, 0, 0, 1, 2, 0, 1 }, // Row 0
        { 1, 0, 0, 1, 2, 0, 1 }, // Row 1
        { 1, 0, 0, 1, 2, 0, 1 }  // Row 2
    };
    
    PullNonZerosToLeft(array, 1);
    
    for (int row = 0; row <= array.GetUpperBound(0); row++)
    {
        for (int col = 0; col <= array.GetUpperBound(1); col++)
        {
            Console.Write("{0} ", array[row,col]);
        }
        Console.WriteLine();
    }
