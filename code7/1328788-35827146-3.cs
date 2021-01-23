    string BinaryStringBitwiseOR(string a, string b, StringBuilder stringBuilder = null)
    {
        if (a.Length != b.Length)
        {
            throw new ArgumentException("The length of given string parameters didn't match");
        }
        if (stringBuilder == null)
        {
            stringBuilder = new StringBuilder(a.Length);
        }
        else
        {
            stringBuilder.Clear().EnsureCapacity(a.Length);
        }
        for (int i = 0; i < a.Length; i++)
        {
            stringBuilder.Append((char)(a[i] | b[i]));
        }
        return stringBuilder.ToString();
    }
