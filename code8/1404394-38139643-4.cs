    foreach (Base value in dictionary.Values)
    {
        var derived = value as Derived;
        if (derived != null)
        {
            Console.WriteLine("{0} is Derived and has Description: {1}",
                               derived.Name, derived.Description);
        }
    }
