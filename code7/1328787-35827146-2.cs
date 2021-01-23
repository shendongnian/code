    string BinaryStringBitwiseOR(string a, string b)
    {
        var stringBuilder = new StringBuilder(a.Length);
        return BinaryStringBitwiseOR(a, b, stringBuilder);
    }
    string BinaryStringBitwiseOR(string a, string b, StringBuilder stringBuilder)
    {
        if (a.Length != b.Length)
        {
            throw new ArgumentException("The length of given string parameters didn't match");
        }
        for (int i = 0; i < a.Length; i++)
        {
            stringBuilder.Append((char)(a[i] | b[i]));
        }
        return stringBuilder.ToString();
    }
