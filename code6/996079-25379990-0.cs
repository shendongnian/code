    String s = "99";
    if (Regex.IsMatch(s, @"^(?:100|[1-9]?[0-9])$")) {
    Console.WriteLine("Correct");
    }
    else {
    Console.WriteLine("Wrong");
    }
