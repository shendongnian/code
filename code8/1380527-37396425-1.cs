    // ItemArray is object[]
    foreach (var item in datarow.ItemArray)
    {
        if (first)
        {
            first = false;
        }
        else
        {
            // I think you are expecting to see the comma here even the previous element is empty e.g. A,B,,D (that missing C)
            Console.Write(",");
        }
        // so here we cannot guarantee "if (item is string)"
        if (item != null)
        {
            Console.Write(item.ToString());
        }
    }
