    class Program
    {
        private static void Main(string[] args)
        {
            var input= Console.ReadLine();
            var parts = input.SplitInParts(3);
            Console.WriteLine(String.Join(" ", parts));   
       }
    }
     public static class Util
    {
        public static IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", "partLength");
            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }
    }
