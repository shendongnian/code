    var line1 = "café";   // precomposed character 'é' (U+00E9)
    var line2 = "café";   // base letter e (U+0065) and combining acute accent (U+0301)
    var sub = "cafe";
    Console.WriteLine(line1.StartsWith(sub));                             // false
    Console.WriteLine(line2.StartsWith(sub));                             // false
    Console.WriteLine(line1.StartsWith(sub, StringComparison.Ordinal));   // false
    Console.WriteLine(line2.StartsWith(sub, StringComparison.Ordinal));   // true
