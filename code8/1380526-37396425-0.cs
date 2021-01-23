    // ItemArray is object[]
    foreach (var item in datarow.ItemArray)
    {
        if (first)
        {
            first = false;
        }
        else
        {
            Console.Write(",");
        }
        // so here we cannot guarantee "if (item is string)"
        if (item != null)
        {
            Console.Write(item.ToString());
        }
    }
