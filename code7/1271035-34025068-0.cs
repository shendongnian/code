    string someVariable = string.Empty;
    Dictionary<string, Action<string>> map = new Dictionary<string, Action<string>>();
    map.Add("someText", (input) => someVariable = input);
    map["someText"]("someInput");
    Console.WriteLine(someVariable);
