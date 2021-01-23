    int[] array1 = new int[] { 3, 5, 6, 9, 12, 14, 18, 20, 25, 28 };
    int[] array2 = new int[] { 30, 32, 34, 36, 38, 40, 42, 44, 46, 48 };
    
    int count1 = array1.Length;
    int count2 = array2.Length;
    int[] arrayResult = new int[count1 + count2];
    
    int a = 0, b = 0;   // indexes in origin arrays
    int i = 0;          // index in result array
    
    // join
    while (a < count1 && b < count2)
    {
        if (array1[a] <= array2[a])
        {
            arrayResult[i++] = array1[a++];
        }
        else
        {
            arrayResult[i++] = array2[b++];
        }
    }
    
    // tail
    if (a < count1)
    {
        for (int j = a; j < count1; j++)
        {
            arrayResult[i++] = array1[j];
        }
    }
    else
    {
        for (int j = b; j < count2; j++)
        {
            arrayResult[i++] = array2[j];
        }
    }
    
    // print result
    Console.WriteLine("Result is {{ {0} }}", string.Join(",", arrayResult.Select(e => e.ToString())));
