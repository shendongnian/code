    public static string PerformReplacements(string text)
    {
        char[] chars = text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            switch (chars[i])
            {
                case 'A':
                    chars[i] = 'B';
                    break;
                case 'B':
                    chars[i] = 'A';
                    break;
            }
        }
        return new string(chars);
    }
