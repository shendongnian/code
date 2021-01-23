    var germanCulture = new CultureInfo("de-DE");
    System.Threading.Thread.CurrentThread.CurrentCulture   = germanCulture;
    System.Threading.Thread.CurrentThread.CurrentUICulture = germanCulture;
    string s = "ß";
    Console.WriteLine(s.ToUpper()); // Prints ß
    Console.WriteLine(s.ToLower()); // Prints ß
