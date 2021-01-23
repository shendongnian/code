    class Program
    {
        public static int EnumerableCount;
        static void Main(string[] args)
        {
            EnumerableCount = 0;
            try
            {
                foreach (var str in GetStrings())
                {
                    Console.WriteLine(str);
                    Console.Read();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.Read();
            }
        }
        private static IEnumerable<string> GetStrings()
        {
            EnumerableCount++;
            var errorMessage = string.Format("EnumerableCount: {0}", EnumerableCount);
            throw new Exception(errorMessage);
            yield break;
        }
    }
