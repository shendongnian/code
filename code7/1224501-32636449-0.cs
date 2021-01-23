    class Program
    {
        static List<int> currentMatchList = new List<int>();
        static void Main()
        {
            int matchSum = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int combinations = (int)Math.Pow(2, numbers.Length);
            List<int> currentSequence = new List<int>();
            HashSet<string> allResults = new HashSet<string>();
    
            bool foundMatch = false;
    
            for (int i = 1; i < combinations; i++)
            {
                for (int bit = 0; bit < Convert.ToString(i, 2).Length; bit++)
                {
                    int mask = (i >> bit) & 1;
                    if (mask == 1)
                    {
                        currentSequence.Add(numbers[numbers.Length - bit - 1]);
                    }
                }
                if (currentSequence.Sum() == matchSum)
                {
                    string temp = "";
                    currentSequence.OrderBy(a => a).ToList().ForEach(a => temp += a + " ");
                    if (!allResults.Contains(temp))
                    {
                        allResults.Add(temp);
                        Console.WriteLine("{0} = {1}", string.Join(" + ", currentSequence), matchSum);
                    }
                    foundMatch = true;
                }
                currentSequence.Clear();
            }
    
            if (!foundMatch)
            {
                Console.WriteLine("No matching subsets.");
            }
        }
    }
