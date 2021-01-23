    var line1 = "café";   // 63 61 66 E9     – precomposed character 'é' (U+00E9)
    var line2 = "café";   // 63 61 66 65 301 – base letter e (U+0065) and
                          //                   combining acute accent (U+0301)
    var sub   = "cafe";   // 63 61 66 65 
    Console.WriteLine(line1.StartsWith(sub));                             // false
    Console.WriteLine(line2.StartsWith(sub));                             // false
    Console.WriteLine(line1.StartsWith(sub, StringComparison.Ordinal));   // false
    Console.WriteLine(line2.StartsWith(sub, StringComparison.Ordinal));   // true
