    String s = "0787654321";
    if (Regex.IsMatch(s, @"^[^.]+$")) {
    Console.WriteLine("Correct format");
    }
    else {
    Console.WriteLine("Error! Wrong format.");
    }
