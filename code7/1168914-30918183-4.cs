    var temp1a = expr1("a string");
    var temp1b = expr1("a string");
    var temp2 = expr2("same string");
    Console.WriteLine(temp1a.Parameters[0] == temp1b.Parameters[0]); // False
    Console.WriteLine(temp1a.Parameters[0] == temp2.Parameters[0]); // False
