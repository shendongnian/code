    //values used for the benchmark
    int[] src = { 1, 2, 3 };
    int[] destArray = { 4, 5, 6, 7 };
    var destList = new List<int>() { 4, 5, 6, 7 };
    //Array.Copy() test : avarage 1004 ms
    for (int i = 0; i < 20000000; i++)
    {
        Array.Copy(src, destArray, src.Length);
    }
    //Your solution test : avarage 634 ms
    for (int i = 0; i < 20000000; i++)
    {
        Copy(src, destList, src.Length);
    }
    public void Copy(int[] sourceArray, List<int> destinationList, int length)
    {
        for (int i = 0; i < length; i++)
        {
            destinationList[i] = sourceArray[i];
        }
    }
