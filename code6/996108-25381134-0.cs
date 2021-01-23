    public static string MyPrefixReplace(string input, string replacer, char prefixChar = '.')
    {
        int index = input.IndexOf(prefixChar);
        if (index == -1)
            return input;
        return replacer + input.Substring(index);
    }
