    foreach (var item in query)
    {
        if(String.IsNullOrWhiteSpace(item.Items))
            Console.WriteLine(item.Value);
        else
            Console.WriteLine("{0}({1})", item.Key, item.Items);
    }
