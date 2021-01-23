    using System.Text.RegularExpressions;
    ...
    var s1 = @"DIST:AGT:SE1111\DIST:AFTER:EXT:22222\Agent";
    var matches = Regex.Matches(s1, @"\d+");
    foreach(Match match in matches)
    {
        Console.WriteLine(match.Value);
    }
    Console.ReadKey(false);
