    public static void _Main(string[] args)
    {
        string[] exponentials = new string[] { "1.23E+4", "1.23E+04", "1.23e+4", "1.23", "1.23e+4e+4", "abce+def", "1.23E-04" };
        for (int i = 0; i < exponentials.Length; i++)
            Console.WriteLine("Input: {0}; Result 1: {1}; Result 2: {2}; Result 3: {3}", exponentials[i], (ParseExponential1(exponentials[i]) ?? 0), (ParseExponential2(exponentials[i]) ?? 0), (ParseExponential3(exponentials[i]) ?? 0));
    }
    public static double? ParseExponential1(string input)
    {
        if (input.Contains("e") || input.Contains("E"))
        {
            string[] inputSplit = input.Split(new char[] { 'e', 'E' });
            if (inputSplit.Length == 2) // If there were not two elements split out, it's an invalid exponential.
            {
                double left = 0;
                int right = 0;
                if (double.TryParse(inputSplit[0], out left) && int.TryParse(inputSplit[1], out right) // Parse the values
                    && (left >= -5.0d && left <= 5.0d && right >= -324) // Check that the values are within the range of a double, this is the minimum.
                    && (left >= -1.7d && left <= 1.7d && right <= 308)) // Check that the values are within the range of a double, this is the maximum.
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
        if (input.Contains("e") || input.Contains("E"))
        {
            double result = 0;
            if (double.TryParse(input, out result))
                return result;
        }
        return null;
    }
    public static double? ParseExponential3(string input)
    {
        double result = 0;
        if (double.TryParse(input, out result))
            return result;
        return null;
    }
