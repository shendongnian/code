    public static bool NumberOfEvensEqualsNumberOfOdds(IEnumerable<int> numbers)
    {
        int evenCount = 0;
        int oddCount = 0;
        foreach (var item in numbers)
        {
            if (item % 2 == 0)
                evenCount++;
            else if (item % 2 != 0)
                oddCount++;  
        }
        return evenCount == oddCount;
    }
