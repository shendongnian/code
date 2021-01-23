    static void Main(string[] args)
    {
        decimal[,] testData = new[,] {{1m, 2m}, {3m, 4m}};
        ImmutableMatice matrix = new ImmutableMatice(testData);
        Console.WriteLine(matrix[0,0]); // writes 1
        testData[0, 0] = 999; // <--- THATS YOUR PROBLEM
        Console.WriteLine(matrix[0,0]); // writes 999 but i thought it should 
                                        // write 1 because class should be immutable?
    }
