    public static int Ord(string str) {
        var bytes = Encoding.Unicode.GetBytes(str);
        return BitConverter.ToChar(bytes, 0);
    }
    
