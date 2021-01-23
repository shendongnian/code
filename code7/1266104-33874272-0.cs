    static void Main(string[] args)
    {
        var arr = new byte[960];
    
        for (int i = 0; i != arr.Length; i++)
        {
            arr[i] = byte.MaxValue;
        }
    
        var big = new BigInteger(arr);
    }
