    int a = 10;
    List<int> list = new List<int> {13, 12, 11, 9};
    int min = -1;
    for (int c = 0; c < list.Count; c++)
    {
        int tempResult = list[c] - a;
        if (tempResult >= 0)
        {
            min = tempResult;
        }
    }
    Console.WriteLine(min);
