    var splitString = row.Split(';');
    if (splitString == null || splitString.Length == 0)
    {
        Console.WriteLine("Split string is null or empty!");
    }
    else
    {
        var wiersz = splitString[1] + splitString[2];
    }
    
