    Func<int> GetExpression(int a, List<int> b)
    {
        return () => a + b.Count;
    }
    int x = 10;
    List<int> list = new List<int> { 1, 2, 3 };
    var expression = GetExpression(x, list);
    Console.WriteLine(expression()); // 13
    x = 20;
    list.Add(100);
    Console.WriteLine(expression()); // 14
