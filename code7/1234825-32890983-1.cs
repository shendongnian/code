    var listOfStrings = "01.02.03.04";
    var arr = listOfStrings.Split(new char[] { '.' });        
    List<string> results = new List<string>();
           
    for (int i = 1; i < arr.Length; i++)
    {
        var str = String.Join(".", arr.Reverse().Skip(i).Reverse());
        results.Add(str);
    }
    foreach (var r in results)
        Console.WriteLine(r);
    //  01.02.03
    //  01.02
    //  01
