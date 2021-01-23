    private string ReadString(Stream s, char delimiter)
    {
        var result = new List<char>();
        int c;
        while ((c = s.ReadByte()) != -1 && (char)c != delimiter)
        {
            result.Add((char)c);
        }
        return new string(result.ToArray());
    }
