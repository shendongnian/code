    static int search(byte[] haystack, byte[] needle)
    {
        for (int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            if (match(haystack, needle, i))
            {
                return i;
            }
        }
        return -1;
    }
    
    static bool match(byte[] haystack, byte[] needle, int start)
    {
        if (needle.Length + start > haystack.Length)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < needle.Length; i++)
            {
                if (needle[i] != haystack[i + start])
                {
                    return false;
                }
            }
            return true;
        }
    }
