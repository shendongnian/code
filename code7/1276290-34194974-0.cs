        static Random random = new Random();
        static List<int> questionNumbers = new List<int>();
        static void Main(string[] args)
        {
            for (int i = 0; i < 70; i++)
            {
                questionNumbers.Add(i);
            }
            List<int> randomAndUniqueNumbers = GenerateRandom(50);
        }
        //This function doesn't require index in questionNumbers
        //to be from 0 and continuous
        public static List<int> GenerateRandom(int count)
        {
            List<int> lst = new List<int>();
            List<int> q = questionNumbers.ToList();
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(0, q.Count);
                lst.Add(q[index]);
                q.RemoveAt(index);
            }
            return lst.OrderBy(x => x).ToList();
        }
