    public static bool FileContainsString(string path, string str, bool caseSensitive = true)
    {
         if(String.IsNullOrEmpty(str))
            return false;
        using (var stream = new StreamReader(path))
        while (!stream.EndOfStream)
        {
            bool stringFound = true;
            for (int i = 0; i < str.Length; i++)
            {
                char strChar = caseSensitive ? str[i] : Char.ToUpperInvariant(str[i]);
                char fileChar = caseSensitive ? (char)stream.Read() : Char.ToUpperInvariant((char)stream.Read());
                if (strChar != fileChar)
                {
                    stringFound = false;
                    break; // break for-loop, start again with first character at next position
                }
            }
            if (stringFound) 
                return true;
        }
        return false;
    }
 
               
----------
    bool containsString = FileContainsString(path, "mySpecialString", false); // ignore case if desired
