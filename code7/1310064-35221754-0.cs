    public char[] GetChars(string input)
    {
        char[] charArray = input.ToCharArray();
        char[] result = new char[] { charArray.First(), charArray.Last() };
        return result;
    }
