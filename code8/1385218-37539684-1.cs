    bool isInt = true;
    string[] str = "1,2,3,4".Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
    int counter = 0;
    List<int> parsedInts = new List<int>(str.Length);
    
    while(isInt && counter < str.Length)
    {
        int parsedInt;
        isInt = int.TryParse(str[counter], out parsedInt);
        counter++;
        if (isInt) {
            parsedInts.Add(parsedInt);
        }
    }
    // then you can return the list as an array if you want
    parsedInts.ToArray();
