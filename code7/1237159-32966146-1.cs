    var germanCulture = new CultureInfo("de-DE");
    System.Threading.Thread.CurrentThread.CurrentCulture   = germanCulture;
    System.Threading.Thread.CurrentThread.CurrentUICulture = germanCulture;
    string s = "ß";
    Console.WriteLine(s.ToUpper()); // Prints ß
    Console.WriteLine(s.ToLower()); // Prints ß
    // Aside: There's a special "uppercase" ß, but this isn't
    // returned from "ß".ToUpper();
    string t = "ẞ"; // Special "uppercase" ß.
    Console.WriteLine(t == s); // Prints false.
    Console.WriteLine(s.ToUpper() == t); // Prints false.
