    for (int i = 0; i < 1000000000; i++)
    {
        var foo = new Foo
        {
            Created = DateTime.Now,
            Modified = DateTime.Now
        };
        if (foo.Created != foo.Modified)
        {
            Console.WriteLine("{0} {1} {2}", foo.Created.Ticks, foo.Modified.Ticks, i);
            break;
        }
    }
