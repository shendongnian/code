    // Example string.
    string result = "       helloThere,  ThisIs      AnExampleString       ";
    // Remove leading and trailing white spaces.
    result = result.Trim();
    // Capitalize first letter.
    result = char.ToUpper(result[0]) + result.Substring(1);
    // Replace long white spaces with just one white space,
    // e.g. "Hello      World" -> "Hello World"
    result = Regex.Replace(result, @"[ ]{2,}", " ");
    // Insert spaces before capital letters.
    for (var i = 1; i < result.Length; i++)
    {
        if (char.IsLower(result[i - 1]) && char.IsUpper(result[i]))
        {
            result = result.Insert(i, " ");
        }
    }
    // OUTPUT: "Hello There, This Is An Example String"
