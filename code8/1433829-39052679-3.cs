    var encodings = Encoding.GetEncodings().Select(e => e.GetEncoding()).ToList();
    var asciiCompatible = encodings.Where(e => IsAsciiCompatible(e)).ToList();
    var nonAsciiCompatbile = encodings.Except(asciiCompatible).ToList();
    Console.WriteLine("ASCII compatible: ");
    foreach (var encodingName in asciiCompatible.Select(e => e.EncodingName).OrderBy(n => n))
        Console.WriteLine("* " + encodingName);
    Console.WriteLine();
    Console.WriteLine("Non-ASCII compatible: ");
    foreach (var encodingName in nonAsciiCompatbile.Select(e => e.EncodingName).OrderBy(n => n))
        Console.WriteLine("* " + encodingName);
