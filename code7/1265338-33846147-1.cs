    string[] text = new string[] { "in", "inside", "on", "octopus", "commotion" };
    Regex regex = new Regex(@"(i.*){2}|(o.*){3}|(u.*){4}");
    var lines = text.Where(x => !regex.IsMatch(x)).ToArray(); // text is array containing the words 
    foreach (var s in lines)
    {
        Console.WriteLine(s);
    }
