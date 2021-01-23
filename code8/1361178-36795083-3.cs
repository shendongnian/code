    IEnumerable<char> numbers = Enumerable.Repeat(numbersFromZeroToNine, int.MaxValue)
        .SelectMany(intArr => intArr)
        .Select(i => i.ToString()[0]);
    if (myString.Length < 50)
    {
        var chars = myString.ToCharArray().Concat(numbers).Take(50);
        myString = String.Concat(chars);
    }
