    for (int i = 0; i < T; i++)
    {
        sum = 0;
        for (int j = 1, term = 0; j < input[i]; j++)
        {
            term += j;
            sum += term * 2;
        }
        Console.WriteLine(sum);
    }
