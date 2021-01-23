    List<int> list = new List<int> { 4, 900, 500, 498, 4 };
    var lst = list.Skip(2).Take(3);
    int sum = 0;
    foreach (int num in lst)
    {
        sum += num;
        if (sum >= 1002)
        {
            break;
        }
    }
    Console.WriteLine(sum);
