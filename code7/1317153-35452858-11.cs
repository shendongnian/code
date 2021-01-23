    Console.WriteLine(shouldBeReadOnly.IsReadOnly);  // Readonly? Yep! This prints True.
    Console.WriteLine(shouldBeReadOnly[0]);    // Prints 1.
    Console.WriteLine(shouldBeReadOnly.Count); // Prints 1.
    test[0] = 2;
    test.Add(-1);
    Console.WriteLine(shouldBeReadOnly[0]);    // Prints 2. Oops. It wasn't readonly at all.
    Console.WriteLine(shouldBeReadOnly.Count); // Prints 2.
