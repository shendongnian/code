    class Program
    {
        static void Main(string[] args)
        {
            List<int> questionNumbers = new List<int>();
            for (int i = 0; i < 70; i++)
            {
                questionNumbers.Add(i);
            }
            List<int> randomAndUniqueNumbers = questionNumbers.GenerateRandom(50);
        }
        
    }
    public static class Extensions
    {
        static Random random = new Random();
        public static List<T> GenerateRandom<T>(this List<T> collection, int count)
        {
            return collection.OrderBy(d => random.Next()).Take(count).ToList();
        }
    }
