    public static bool isValid(string input)
    {
        if(input.Length < 3 || input.All(c => char.IsLetter(c))) 
        {
            return false;
        }
        return input.All(c => char.IsLetterOrDigit(c));
    }
