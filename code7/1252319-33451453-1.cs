    private char? FirstConsecutiveCharacter(string input)
    {
        for (var i = 1; i < input.Length; ++i)
        {
            if (input[i] == input[i - 1])
            {
                return input[i];
            }
        }
        return null;
    }
