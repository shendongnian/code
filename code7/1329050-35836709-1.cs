    public static string UpperCaseFirstLetter (string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        if (input.Length < 2)
        {
            return input.ToUpper();
        }
        return input[0].ToString().ToUpper() + input.Substring(1);
    }
