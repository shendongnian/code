    private static IEnumerable<string> CustomSplit(string str)
    {
        if (str == null)
        {
            yield break;
        }
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '=' && i < str.Length - 2 && str[i + 1] != '=' && str[i + 2] != '=')
            {
                yield return str.Substring(i + 1, 2);
                i += 2;
            }
            else
            {
                yield return str.Substring(i, 1);
            }
        }
    } 
