    var lines = new string[]
        {
            "22 The cats of India",
            "4 Royal Highness",
            "562 Eating Potatoes",
            "42 Biscuits in the 2nd fridge",
            "2564 Niagara Falls at 2 PM"
        };
    foreach (var line in lines)
    {
        var newLine = string.Join(" ", line.Split(' ').Skip(1));
    }
