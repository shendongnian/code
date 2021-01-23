    var line = "Hello, How are you ? ";
    var pattern = @"\b";
    var words = new HashSet<String>(Regex.Split(line, pattern));
    Console.WriteLine(words.Contains("Hello"));
    Console.WriteLine(words.Contains("ello"));
    Console.WriteLine(words.Contains("How"));
