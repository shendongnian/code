    public static void _Main(string[] args)
    {
        string[] exponentials = new string[] { "1.23E+4", "1.23E+04", "1.23e+4", "1.23", "1.23e+4e+4", "abce+def", "1.23E-04" };
        for (int i = 0; i < exponentials.Length; i++)
            Console.WriteLine("Input: {0}; Result 1: {1}; Result 2: {2}", exponentials[i], (ParseExponential1(exponentials[i]) ?? 0), (ParseExponential2(exponentials[i]) ?? 0));
    }
    public static double? ParseExponential1(string input)
    {
        input = input.Replace('E', 'e'); // Shrink the 'E'.
        if (input.Contains("e"))
        {
            string[] inputSplit = input.Split('e');
            if (inputSplit.Length == 2) // If there were not two elements split out, it's an invalid exponential.
            {
                decimal left = 0;
                int right = 0;
                if (decimal.TryParse(inputSplit[0], out left) && int.TryParse(inputSplit[1], out right))
                {
                    double result = 0;
                    if (double.TryParse(input, out result))
                        return result;
                }
            }
        }
        return null;
    }
    public static double? ParseExponential2(string input)
    {
        input = input.Replace('E', 'e'); // Shrink the 'E'.
        if (input.Contains("e"))
        {
            double result = 0;
            if (double.TryParse(input, out result))
                return result;
        }
        return null;
    }
