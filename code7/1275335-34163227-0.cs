    private static void Main(string[] args)
            {
                var sequence = GeneratePrbSsequences(15);
                Console.WriteLine(string.Join("\n",sequence));
                Console.WriteLine("Repetition Period = {0}", sequence.Count);
                Console.ReadLine();
            }
        static List<string> GeneratePrbSsequences(int number)
        {
            var a = 0x02;
            var period = (int)(Math.Pow(2, number) - 1);
            var sequenceList = new List<string>();
            do
            {
                var v1 = number - 1;
                var v2 = number - 2;
                var newbit = (((a >> v1) ^ (a >> v2)) & 1);
                a = ((a << 1) | newbit) & period;
                sequenceList.Add(string.Format("{0:X2}", a));
                Console.WriteLine();
            } while (a != 0x02);
            return sequenceList;
        }
    }
