    var nodeValue = "Test ID=\"12345\" hello";
    GroupCollection ids = Regex.Match(nodeValue, "ID=\"([^\"]*)").Groups;
    Console.WriteLine(ids[1].Value);
    // or just on one line
    // Console.WriteLine(Regex.Match(nodeValue, "ID=\"([^\"]*)").Groups[1].Value);
