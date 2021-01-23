    private static IEnumerable<string> CustomSplit(string str)
    {
        if (str == null)
        {
            yield break;
        }
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '=' && i < str.Length - 1)
            {
                yield return str.Substring(i + 1, Math.Min(2, str.Length - i - 1));
                i += 2;
            }
            else
            {
                yield return str.Substring(i, 1);
            }
        }
    } 
