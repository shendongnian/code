    var line1 = "café";
    var line2 = "café";
    var sub = "cafe";
    Console.WriteLine(line1.StartsWith(sub));                             // false
    Console.WriteLine(line2.StartsWith(sub));                             // false
    Console.WriteLine(line1.StartsWith(sub, StringComparison.Ordinal));   // false
    Console.WriteLine(line2.StartsWith(sub, StringComparison.Ordinal));   // true
