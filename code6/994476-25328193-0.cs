    using System;
    class Program
    {
    static void Main()
    {
        int factor = 65536;
        
        String cell = "660013103525";
        
        String str = cell.Substring(cell.Length - 8);
        
        long cellValue = Convert.ToInt64(str);
        
        long part1 = cellValue / factor * 100000;
        
        long part2 = cellValue % factor;
        
        long result = part1 + part2;
        
        Console.WriteLine("Input: " + cell);
        Console.WriteLine("Output: " + result);
    }
}
