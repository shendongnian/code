        string[] array = {"A", "B", "C", "D"};
        var pairs = new List<string[]>();
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                pairs.Add(new []
                {
                    array[i],
                    array[j]
                });
            }
        }
        /*output of pairs
        A, B
        A, C
        A, D
        B, C
        B, D
        C, D
        */
