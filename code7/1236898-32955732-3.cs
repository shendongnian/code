    string myString = "ABC";
    List<string> subStrings = new List<string>{"A", "B", "C"};
    switch (subStrings.FirstOrDefault(myString.Contains))
    {
        case "A":
            Console.WriteLine("Has A");
            break;
        case "B":
            Console.WriteLine("Has B");
            break;
        case "C":
            Console.WriteLine("Has C");
            break;
        default:
            Console.WriteLine("No ABC");
            break;
    }
