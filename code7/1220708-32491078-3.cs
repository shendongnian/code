    public static bool AreStringEqual(string str1, string str2)
    {
        if (str1.Length != str2.Length)
        {
            return false;
        }
        for(var counter = 0; counter < str1.Length; counter++)
        {
            if (str1[counter] != str2[counter])
            {
                return false;
            }
        }
        return true;
    }
