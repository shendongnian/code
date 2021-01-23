    var input = new string[]
    {
        "AB",
        "123",
        "@#",
    };
    foreach (var result in input.MultiCartesian(x => new string(x)))
    {
        Console.WriteLine(result);
    }
    // Results:
    // A1@
    // A1#
    // A2@
    // A2#
    // A3@
    // A3#
    // B1@
    // B1#
    // B2@
    // B2#
    // B3@
    // B3#
