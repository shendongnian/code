    class Program
    {
        static void Main()
        {
            Console.WriteLine(IsPalindrome("ABCDEFG")); // Prints false
            Console.WriteLine(IsPalindrome("ABCDCBA")); // Prints true
        }
        public static bool IsPalindrome(string text)
        {
            return isPalindrome(0, text.Length - 1, text);
        }
        private static bool isPalindrome(int indexOfFirst, int indexOfLast, string text)
        {
            if (indexOfFirst >= indexOfLast)
                return true;
            if (text[indexOfFirst] != text[indexOfLast])
                return false;
            return isPalindrome(indexOfFirst + 1, indexOfLast - 1, text);
        }
    }
