    public static bool FileContainsString(string path, string str)
    {
        if(String.IsNullOrEmpty(str))
            return false;
        using (var stream = new StreamReader(path))
        while (!stream.EndOfStream)
        {
            bool stringFound = true;
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] != (char)stream.Read())
                {
                    stringFound = false;
                    break; // break for-loop, start again with first character at next position
                }
            }
            if(stringFound) 
                return true;
        }
        return false;
    }
