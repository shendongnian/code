    int[] array1 = new int[] { 14, 2, 3, 8, 10, 2, 7, 9 };
    int[] array2 = new int[] { 353, 588, 353, 213, 588, 213, 200, 353 };
    
    // merge
    Dictionary<int, int> dic = new Dictionary<int, int>();
    int count = array1.Length;
    int sum;
    for (int i = 0; i < count; i++)
    {
        int a = array1[i];
        int b = array2[i];
        dic[b] = a + (dic.TryGetValue(b, out sum) ? sum : 0);
    }
    
    int[] convertedArray1 = dic.Values.ToArray();
    int[] convertedArray2 = dic.Keys.ToArray();
    
    // result is:
    // convertedArray1 = { 26, 12, 10, 7 }
    // convertedArray2 = { 353, 588, 213, 200 }
