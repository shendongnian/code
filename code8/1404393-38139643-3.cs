    foreach (Base value in dictionary.Values)
    {
        if (value is Derived)
        {
            Console.WriteLine("{0} is Derived", value.Name);
            // trying to access value.Description at this point
            // would cause a compiler error "Cannot resolve symbol".
        }
        else
        {
            Console.WriteLine("{0} is not Derived", value.Name);
        }
    }
