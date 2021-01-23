    var ints = new HashSet<int>(); // creating HashSet
    ints.Add(1); // adding items to HashSet
    if (ints.Contains(1)) // check if HashSet already has the value
    {
        Console.WriteLine("number already exist");
    }
    if (!ints.Add(1)) // check if the added value already exists
    {
        Console.WriteLine("number already exist");
    }
    var list = ints.ToList(); //converting HashSet to List
