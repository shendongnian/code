    private List<int> DecimalToBinary(int number, int digitCount)
    {
        // The number can't itself have more than 32 digits, so there's
        // no point in allowing the caller to ask for more than that.
        if (digitCount < 1 || digitCount > 32)
        {
            throw new ArgumentOutOfRangeException("digitCount",
                "digitCount must be between 1 and 32, inclusive");
        }
        long[] digitValues = Enumerable.Range(0, digitCount)
            .Select(i => (long)Math.Pow(2, digitCount - i - 1)).ToArray();
        List<int> binaryDigits = new List<int>(digitCount);
        for (int i = 0; i < digitValues.Length; i++)
        {
            if (digitValues[i] <= number)
            {
                binaryDigits.Add(1);
                number = (int)(number - digitValues[i]);
            }
            else
            {
                binaryDigits.Add(0);
            }
        }
        if (number > 0)
        {
            throw new ArgumentOutOfRangeException("digitCount",
                "digitCount was not large number to accommodate the number");
        }
        return binaryDigits;
    }
