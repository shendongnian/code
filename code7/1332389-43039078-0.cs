    /// <summary>
    /// Iterates through the characters in a phone number converting letters to digits.
    /// </summary>
    /// <remarks>Uses StringBuilder to build the output iteratively, this method does not attempt to validate the number passed in</remarks>
    /// <see cref="LetterNumber"/>
    /// <param name="str">Phone number to parse</param>
    /// <returns>Phone number output where letters have been parsed into their digit values</returns>
    private string ParsePhoneNumber_StringBuilder(string str)
    {
        StringBuilder output = new StringBuilder();
        foreach (char ch in str.ToCharArray())
        {
            // Convert each letter to it's numeric value as defined in the LetterNumber enum
            // Dashes are not letters so they will get passed through
            if (char.IsLetter(ch))
            {
                if (Enum.IsDefined(typeof(LetterNumber), ch.ToString()))
                {
                    LetterNumber letterNumber = (LetterNumber)Enum.Parse(typeof(LetterNumber), ch.ToString(), true);
                    output.Append((int)letterNumber);
                }
            }
            else
                output.Append(ch);
        }
        return output.ToString();
    }
    /// <summary>
    /// Uses Linq to parse the characters in a phone number converting letters to digits.
    /// </summary>
    /// <remarks>This method does not attempt to validate the number passed in</remarks>
    /// <see cref="LetterNumber"/>
    /// <param name="str">Phone number to parse</param>
    /// <returns>Phone number output where letters have been parsed into their digit values</returns>
    private string ParsePhoneNumber_Linq(string str)
    {
        return String.Join("", str.Select(c => char.IsLetter(c) ? ((int)((LetterNumber)Enum.Parse(typeof(LetterNumber), c.ToString(), true))).ToString() : c.ToString()));
    }
    /// <summary>
    /// Iterates through the LetterNumber values and replaces values found in the passed in phone number.
    /// </summary>
    /// <remarks>Iterates through Enum Names and applied String.Replace</remarks>
    /// <see cref="LetterNumber"/>
    /// <param name="str">Phone number to parse</param>
    /// <returns>Phone number output where letters have been parsed into their digit values</returns>
    private string ParsePhoneNumber_Replacement(string str)
    {
        str = str.ToUpper(); // we will compare all letters in upper case
        foreach (string letter in Enum.GetNames(typeof(LetterNumber)))
            str = str.Replace(letter.ToUpper(), ((int)((LetterNumber)Enum.Parse(typeof(LetterNumber), letter))).ToString());
        return str;
    }
