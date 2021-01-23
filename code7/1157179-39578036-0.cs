    string test1 = "&";
    string test2 = "&&&&&&&&&&";
    string test3 = "&&&&&&&u&&&&&&&";
    var test4 = "foo&";
    var regex = new Regex("^[&]+$");
    
    Console.WriteLine(regex.IsMatch(test1));
    Console.WriteLine(regex.IsMatch(test2));
    Console.WriteLine(regex.IsMatch(test3));
    Console.WriteLine(regex.IsMatch(test4));
