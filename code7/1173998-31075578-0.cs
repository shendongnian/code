    static class StringExtension
            {
                public static bool ContainsWord(this string s, string word)
                {
                    string[] ar = s.Split(' ');
    
                    foreach (string str in ar)
                    {
                        if (str.ToLower() == word.ToLower())
                            return true;
                    }
                    return false;
                }
            }
