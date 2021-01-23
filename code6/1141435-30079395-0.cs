    public static bool FileContainsString(string path, string str, StringComparer comparer)
    {
        using (var stream = new StreamReader(path))
        while (!stream.EndOfStream)
        {
            char c = (char)stream.Peek();
            if (c == str[0])
            {
                char[] buffer = new char[str.Length];
                stream.Read(buffer, 0, buffer.Length);
                if (comparer.Equals(str, new string(buffer)))
                    return true;
            }
            else
                stream.Read();
        }
        return false;
    }
