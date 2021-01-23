    static Dictionary<int, string> _monthName = new Dictionary<int, string>
    {
        {1,"January" }, // if zero based start from 0
        {2,"February" },
        {3,"March" },
        {4,"April" },
        {5,"May" },
        {6,"June" },
        {7,"July" },
        {8,"August" },
        {9,"September" },
        {10,"October" },
        {11,"November" },
        {12,"December" },
    };
    private static string GetMonthName(int i)
    {
        var result = "";
        if (_monthName.TryGetValue(i, out result))
        {
            return result;
        }
        return "N/A";
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Month 1: " + GetMonthName(1));
        Console.WriteLine("Month 2: " + GetMonthName(2));
        Console.WriteLine("Month 3: " + GetMonthName(3));
        Console.WriteLine("Month 4: " + GetMonthName(4));
        Console.WriteLine("Month 5: " + GetMonthName(5));
        Console.WriteLine("Month 6: " + GetMonthName(6));
        Console.WriteLine("Month 7: " + GetMonthName(7));
        Console.WriteLine("Month 8: " + GetMonthName(8));
        Console.WriteLine("Month 9: " + GetMonthName(9));
        Console.WriteLine("Month 10: " + GetMonthName(10));
        Console.WriteLine("Month 11: " + GetMonthName(11));
        Console.WriteLine("Month 12: " + GetMonthName(12));
        Console.WriteLine("Month 43: " + GetMonthName(43));
        Console.ReadKey();
    }
