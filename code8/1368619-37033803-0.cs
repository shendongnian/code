    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Possible combinations with m=8, z=2");
            var possibleLines = GetPossibleLines(8, 2).ToArray();
            for (int i = 0; i < possibleLines.Length; i++)
            {
                for (int j = 0; j < possibleLines[i].Length; j++)
                {
                    Console.Write(possibleLines[i][j] ? 1 : 0);
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine("And the Matrices:");
            foreach (var matrix in GetMatrices(8,5,2))
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        Console.Write(matrix[i][j] ? 1 : 0);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine("---------------End------------------");
        }
        private static IEnumerable<bool[][]> GetMatrices(int m, int n, int z)
        {
            var possibleLines = GetPossibleLines(m, z).ToArray();
            var lineCombinations = GetPossibleLines(possibleLines.Length, n).ToArray();
            for (int i = 0; i < lineCombinations.Length; i++)
            {
                int combinationIndex = 0;
                bool[][] result = new bool[n][];
                for (int j = 0; j < lineCombinations[i].Length; j++)
                {
                    if (!lineCombinations[i][j])
                    {
                        result[combinationIndex++]= possibleLines[j];
                    }
                }
                yield return result;
            }
        }
        private static IEnumerable<bool[]> GetPossibleLines(int m, int z)
        {
            for (int i = 1; i < Math.Pow(2, m); i++)
            {
                var remainder = i;
                var remainingZ = z;
                bool[] result = new bool[m];
                for (int j = 0; j < m && remainingZ > -1; j++)
                {
                    bool b = remainder % 2 == 1;
                    result[j] = b;
                    remainder /= 2;
                    if (!b)
                    {
                        remainingZ--;
                    }
                }
                if (remainder == 0 && remainingZ == 0)
                {
                    yield return result;
                }
            }
        }
    }
