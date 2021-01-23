    string ReadFileAsHexString(string filename)
    {
        var bytes = File.ReadAllBytes(filename);
        return bytes.Aggregate(new StringBuilder(), 
                               (sb, v) => sb.AppendFormat("{0:X2} ", v))
                    .ToString();
    }
    void WriteHexStringAsBinaryToFile(string hex, string filename)
    {
        var bytes = hex.Split(new [] {' '},  StringSplitOptions.RemoveEmptyEntries)
                       .Select(s => Convert.ToByte(hex, 16))
                       .ToArray();
        File.WriteAllBytes(filename, bytes);
    }
