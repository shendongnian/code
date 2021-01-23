    static void Main(string[] args)
    {
        var result = Convert(new List<int>(), 192);
    }
    static List<int> Convert(List<int> bits, int n)
    {
        if (n < 1)
        {
            return bits;
        }
        else
        {
            bits.Add(n % 2);
            return Convert(bits, n / 2);
        }
    }
