    static void Main(string[] args)
    {
        // Input:
        String[] values = { "A1", "B1", "C1", "5" };
        // Results:
        String[] digits = (from x in values where StringContainsNumbersOnly(x) select x).ToArray();
        String[] cellRefs = (from x in values where !digits.Contains(x) select x).ToArray();
    }
    static bool StringContainsNumbersOnly(string inputString)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(inputString, @"^\d+$");
    }
