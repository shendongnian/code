    string input = "YOUR STRING HERE";
    Regex rgx = new Regex("max=\".*?\"");
    string result = rgx.Replace(input, "max=\"0.99\"");
    Console.WriteLine("Original String: {0}", input);
    Console.WriteLine("Replacement String: {0}", result);
