    List<int> test = new List<int> {1};
    IReadOnlyList<int> readOnly = test; // Because List<T> implements IReadOnlyList<int>.
    Console.WriteLine(readOnly[0]);  // Prints 1.
    test[0] = 2;
    Console.WriteLine(readOnly[0]);  // Prints 2. Oops.
