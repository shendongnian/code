    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter String:");
            var input = Console.ReadLine();
            Console.WriteLine(ReverseWords(input));
            Console.ReadKey();
        }
        private static string ReverseString(string input)
        {
            var chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
        private static string ReverseWords(string input)
        {
            var sb = new StringBuilder();
            input.Split(' ').ToList().ForEach(c =>
            {
                sb.AppendFormat("{0} ", ReverseString(c));
            });
            return sb.ToString();
        }
    } 
