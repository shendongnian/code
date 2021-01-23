    var listOfStrings = "01.02.03.04";
    var separatedStringList = listOfStrings.Split('.').ToList();
    var list =
        Enumerable.Range(1, separatedStringList.Count - 1)
            .Select(i => string.Join(".", separatedStringList.Take(i)))
            .ToList();
    foreach(var s in list) Console.WriteLine(s);
