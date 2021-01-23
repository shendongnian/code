    string[] sentences =
    {
        "Hello",
        "helloworld",
        "hello_world",
        "hello_world_"
    };
    foreach (string s in sentences)
    {
        string pattern = "_world";
        string result = s.Replace(pattern, "_charp");
        Console.WriteLine(s + " = " + result);
    }
