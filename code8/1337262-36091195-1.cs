    var test = "";
    var test2 = "";
    if (String.IsNullOrEmpty(test?.Trim()) && String.IsNullOrEmpty(test2?.Trim()))
    {
        Console.WriteLine("both strings are null or empty and equal");
    }
    else
    {
        Console.WriteLine("both strings have value and are equal");
    }
