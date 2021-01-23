          int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        List<int> output = new List<int>();
        int i;
        int k = 0;
        int y = 0;
        int z = 1;
        for (i = 0; i < 7; i++)
        {
            output.Add(input[i]);
            output.Add(input[i] + y);
            y = output.Last();
            z = output.Count;
            for (int j = k; j < z; j++)
            {
                Console.Write(output[j] + " ");
            }
            k = output.Count;
            Console.WriteLine();
