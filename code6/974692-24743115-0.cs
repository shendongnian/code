    int i = -2;
    Expression<Func<bool>> expression = () => Interlocked.Increment(ref i) != 0;
    var del = expression.Compile();
    Console.WriteLine(del()); // True
    Console.WriteLine(del()); // False
    Console.WriteLine(del()); // True
    Console.WriteLine(del()); // True
    Console.WriteLine(i);     // 2
