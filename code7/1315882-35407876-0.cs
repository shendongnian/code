    Int64 sum = 0;
    int T = Convert.ToInt32(Console.ReadLine());
    Int64[] input = new Int64[T];
    for (int i = 0; i < T; i++)
        input[i] = Convert.ToInt32(Console.ReadLine());
    for (int i = 0; i < T; i++)
    {
        // int[,] Matrix = new int[input[i], input[i]];
        sum = 0;
        for (int j = 0; j < input[i]; j++)
            for (int k = 0; k < input[i]; k++)
                {
                    //Matrix[j, k] = Math.Abs(j - k);
                    //sum += Matrix[j, k];
                    sum += Math.Abs(j - k);
                }
        Console.WriteLine(sum);
    }
