     private static void Main()
     {
        Console.WriteLine(TestAlphaNumeric("().;"));
        Console.WriteLine(TestAlphaNumeric("(9).;"));
        Console.WriteLine(TestAlphaNumeric(")+&^%"));
        Console.WriteLine(TestAlphaNumeric("A)%$#"));
        Console.Read();
     }
     private static bool TestAlphaNumeric(string str)
     {
        return str.Any(char.IsLetterOrDigit);
     }
