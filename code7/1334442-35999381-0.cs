    class Program
    {
        static void Main(string[] args)
        {
            DisplayDistinctSums(8f);
        }
        static void DisplayDistinctSums(float baseNum)
        {
            DisplayDistinctSums(baseNum, baseNum - 1, "(");
        }
        static void DisplayDistinctSums(float baseNum, float nextNum, string sumString)
        {
            if (baseNum < 1)
            {
                sumString += ")";
                Console.WriteLine(sumString);
                return;
            }
            for (var i = Math.Min(nextNum, baseNum); i >= 1; i--)
            {
                if (!sumString.Contains(i.ToString()))
                {
                    DisplayDistinctSums(baseNum - i, i, 
                        sumString.Length == 1 ? sumString + i : sumString + ", " + i);
                }
            }
        }
    }
