    public static string ShiftText(string input, int shiftAmount)
    {
        if (input == null) return null;
        var result = string.Empty;
        // Loop through input and update result with shifted letters
        foreach (var chr in input)
        {
            if (!char.IsLetter(chr))
            {
                // If the character isn't a letter, don't change it
                result += chr;
            }
            else
            {
                var newChar = chr - shiftAmount;
                // Adjust our newChar to stay within this character range
                if (newChar < (char.IsLower(chr) ? 'a' : 'A')) newChar += 26;
                result += (char) newChar;
            }
        }
        return result;
    }
