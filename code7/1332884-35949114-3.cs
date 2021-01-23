    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new String[] {"Angie", "David", "Emily", "James"};
            var baseSeed = Environment.TickCount;
            for (int i = 0; i < 100; i++)
            {
                Random rnd = new Random(baseSeed + i / 10);
                var shuffled = list.ToList(); //This is so we don't mutate the original list with Shuffle
                shuffled.Shuffle(rnd);
                Console.WriteLine(String.Join(",", shuffled));
                Thread.Sleep(100);
            }
            Console.ReadLine();
        }
    }
