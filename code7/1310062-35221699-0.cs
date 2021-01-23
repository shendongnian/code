    public class Program
    {
        public static void Main(string[] args)
        {
            string myString = "abc";
            var firstAndLast = myString.GetFirstAndLast();
            Console.WriteLine("First: " + firstAndLast[0] + " Last: " + firstAndLast[1]);
        }
        
    }
    
    public static class StringExtensions
    {
        public static char[] GetFirstAndLast(this string str)
        {
            return new char[2] { str.FirstOrDefault(), str.LastOrDefault() };
        }
    }
