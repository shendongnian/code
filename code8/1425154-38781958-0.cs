    /// <summary>
    /// http://stackoverflow.com/questions/38781957
    /// </summary>
    public bool IsValidAcn(string acn)
    {
        int[] weightings = {8, 7, 6, 5, 4, 3, 2, 1};
        var accumulatedSum = 0;
        acn = acn?.Replace(" ", ""); // strip spaces
        if (string.IsNullOrWhiteSpace(acn) || !Regex.IsMatch(acn, @"^\d{9}$"))
        {
            return false;
        }
        
        // Sum the multiplication of all the digits and weights
        for (int i = 0; i < weightings.Length; i++)
        {
            accumulatedSum += Convert.ToInt32(acn.Substring(i, 1)) * weightings[i];
        }
        
        var remainder = accumulatedSum % 10;
        
        var expectedCheckDigit = (10 - remainder == 10) ? 0 : (10 - remainder);
        var actualCheckDigit = Convert.ToInt32(acn.Substring(8, 1));
        return expectedCheckDigit == actualCheckDigit;
    }
