    var list = new List<dynamic>
    {
        new ExpandoObject(),
        new ExpandoObject(),
        new ExpandoObject(),
    };
    list[0].Foo = 1;
    list[1].Foo = 2;
    list[2].Foo = 3;
    var sum = list
        .Sum(_ => _.Foo);
    Console.WriteLine(sum); // displays "6"
