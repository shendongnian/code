    var c = "1" + "2";
    var d = c + "2";
    Console.WriteLine(string.IsInterned(d));
    
    var e = "12";
    Console.WriteLine(string.IsInterned(e));
