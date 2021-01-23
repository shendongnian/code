    foreach (Base value in dictionary.Values)
    {
        Derived derived = value as Derived;
        if (derived != null)
        {
            Console.WriteLine("{0} is Derived and has Description: {1}",
                               derived.Name, derived.Description);
            // now that derived actually is of type Derived,
            // accessing derived.Description is perfectly fine.
        }
    }
