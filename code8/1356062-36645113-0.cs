    int minDelta = int.MaxValue;
    var list1 = new List<ClassName>();
    var list2 = new List<ClassName>();
    for (int i = 0; i < list.Count - 1; i++)
    {
        int count = i + 1;
        int sum1 = list.Take(count).Sum(x => x.Value);
        int sum2 = list.Skip(count).Sum(x => x.Value);
        int delta = Math.Abs(sum1 - sum2);
        if (delta < minDelta)
        {
            minDelta = delta;
            list1 = list.Take(count).ToList();
            list2 = list.Skip(count).ToList();
        }
    }
