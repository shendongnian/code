    static int ConvertFromBase(int num, int @base)
    {
        return num.ToString().Reverse()
                  .Select((c, index) => (int)Char.GetNumericValue(c) * (int)Math.Pow(@base, index))
                  .Sum();
    }
    Console.WriteLine(ConvertFromBase(1234, 5));  // 194
