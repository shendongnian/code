    /// <summary>
    /// This method takes the input string and shifts all letter characters 
    /// to the left (subtracts) by the amount specified in shiftAmount, so 
    /// if shiftAmount = 1, then 'M' becomes 'L', and 'a' becomes 'z'.
    /// </summary>
    /// <param name="input">The input string to apply changes to</param>
    /// <param name="shiftAmount">A value from 0 to 25, used to shift the characters</param>
    /// <returns>The modified (shifted) string</returns>
    public static string ShiftText(string input, int shiftAmount)
    {
        if (input == null) return null;
        var result = string.Empty;
        // Loop through input and update result with shifted letters
        foreach (var character in input)
        {
            if (!char.IsLetter(character))
            {
                // If the character isn't a letter, don't change it
                result += character;
            }
            else
            {
                var newChar = (char) (character - shiftAmount);
                // Adjust newChar to stay within this character range
                if (newChar < (char.IsLower(character) ? 'a' : 'A')) newChar += (char) 26;
                result += newChar;
            }
        }
        return result;
    }
