    List<int> list = new List<int> { 4, 900, 500, 498, 4 };
    var lst = list.Skip(2).Take(3);
    int sum = 0;
    foreach (int num in lst)
    {
        int sum2 = sum + num;
        if (sum2 > 1002)
        {
            break;
        }
        sum = sum2;
    }
    Console.WriteLine(sum);
