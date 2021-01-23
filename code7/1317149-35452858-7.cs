    List<int> test = new List<int> {1};
    var readOnly = test.AsReadOnly();
    IList<int> shouldBeReadOnly = readOnly;
    Console.WriteLine(shouldBeReadOnly.IsReadOnly);  // Readonly? Yep! This prints True.
    Console.WriteLine(shouldBeReadOnly[0]);  // Prints 1.
    test[0] = 2;
    Console.WriteLine(shouldBeReadOnly[0]);  // Prints 2. Oops. It wasn't readonly at all.
