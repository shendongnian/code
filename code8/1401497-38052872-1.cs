    var stack = new Stack<Tuple<MyEnums, int>>();
    stack.Add(new Tuple<MyEnums, int>(MyEnums.Main, Main.PageSelect)); // This will be casted to int
    var tuple = stack.Pop();
    switch(tuple.Item1)
    {
        case MyEnums.Main:
        var ourPage = (Main) tuple.Item2; // Cast back to an appropriate enum
        return RedirectToAction(...);
        ...
    }
