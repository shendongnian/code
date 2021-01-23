    public static List<int> getValue(List<int> numbers)
    {
        List<int> usedNumbers = numbers;
        Random rnd = new Random();
        int tempValue = rnd.Next(0, 27);
        if (usedNumbers.Count == 5)
        {
            return usedNumbers;
        }
        if (usedNumbers.Contains(tempValue))
        {
            return getValue(usedNumbers);
        }
        else
        {
            usedNumbers.Add(tempValue);
            return getValue(usedNumbers);
        }
    }
