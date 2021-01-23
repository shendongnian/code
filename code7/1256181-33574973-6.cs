    result.Subscribe(x =>
    {
        Console.WriteLine(String.Format("New buffer. Count {0}. Sum {1}", x.Count, x.Sum(y => y.Size)));
        foreach (var foo in x)
        {
            Console.WriteLine(foo.Size);
        }
    });
