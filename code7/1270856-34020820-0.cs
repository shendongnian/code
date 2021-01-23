    public byte[][] Split(byte[] input, byte separator, bool ignoreEmptyEntries = false)
    {
        var subArrays = new List<byte[]>();
        var start = 0;
        for (var i = 0; i <= input.Length; ++i)
        {
            if (input.Length == i || input[i] == separator)
            {
                if (!(i - start == 0 && ignoreEmptyEntries))
                {
                    var destination = new byte[i - start];
                    Array.Copy(input, start, destination, 0, i - start);
                    subArrays.Add(destination);
                }
                start = i + 1;
            }
        }
        
        return subArrays.ToArray();
    }
