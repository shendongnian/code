    namespace StackOverflow
    {
        class RandomIDGenerator
        {
            private const string FORMAT = "ABCD-####-####";
            private const string TEST_FORMAT = "ABCD-###";
    
    
            private RandomNumberGenerator rng = RandomNumberGenerator.Create();
            private byte[] b = new byte[1];
            private SortedSet<string> previousIDs = new SortedSet<string>();
    
            private char GenerateRandomDigit()
            {
                int x;
                do
                {
                    rng.GetBytes(b);
                    x = b[0] & 0xFF;
                } while (x >= 250);
                int y = x % 10;
                return (char) ('0' + y);
            }
    
            private String GenerateRandomID()
            {
                StringBuilder sb = new StringBuilder(TEST_FORMAT);
                for (int i = 0; i < sb.Length; i++)
                {
                    if (sb[i] == '#')
                    {
                        sb[i] = GenerateRandomDigit();
                    }
                }
                return sb.ToString();
            }
    
            public String GenerateUniqueRandomID()
            {
                string id;
                do
                {
                    id = GenerateRandomID();
                }
                while (previousIDs.Contains(id));
                previousIDs.Add(id);
                return id;
            }
    
            public static void Main(String[] args)
            {
                RandomIDGenerator gen = new RandomIDGenerator();
                for (int i = 0; i < 500; i++)
                {
                    Console.WriteLine(gen.GenerateUniqueRandomID());
                }
    
                Console.WriteLine("Put breakpoint here...");
    
                foreach (string id in gen.previousIDs)
                {
                    Console.WriteLine(id);
                }
    
                Console.WriteLine(gen.previousIDs.Count);
                Console.WriteLine("Put breakpoint here...");
            }
        }
    }
