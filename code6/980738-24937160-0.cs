    static Dictionary<string, int> dict;
        static void Main(string[] args)
        {
            //This has been assumed that the strings contain only A,C,G,T and -(?)..caps
            Console.WriteLine("Enter first string : ");
            string realInputA = Console.ReadLine();
            string inputA = "-" + realInputA;
            Console.WriteLine("Enter second string : ");
            string realInputB = Console.ReadLine();
            string inputB = "-" + realInputB;
            int[,] scoreMatrix = new int[inputA.Length, inputB.Length];
            #region Create Dictionary
            dict = new Dictionary<string, int>();
            dict.Add("AA", 5);
            dict.Add("AC", -1);
            dict.Add("AG", -2);
            dict.Add("AT", -1);
            dict.Add("A-", -3);
            dict.Add("CA", -1);
            dict.Add("CC", 5);
            dict.Add("CG", -3);
            dict.Add("CT", -2);
            dict.Add("C-", -4);
            dict.Add("GA", -2);
            dict.Add("GC", -3);
            dict.Add("GG", 5);
            dict.Add("GT", -2);
            dict.Add("G-", -2);
            dict.Add("TA", -1);
            dict.Add("TC", -2);
            dict.Add("TG", -2);
            dict.Add("TT", 5);
            dict.Add("T-", -1);
            dict.Add("-A", -3);
            dict.Add("-C", -4);
            dict.Add("-G", -2);
            dict.Add("-T", -1);
            dict.Add("--", 0);
            #endregion Create Dictionary
            for (int i = 0; i < inputA.Length; i++)
            {
                for (int j = 0; j < inputB.Length; j++)
                {
                    int score = 0, score1 = 0, score2 = 0;
                    dict.TryGetValue(inputA[i].ToString() + inputB[j].ToString(), out score);
                    dict.TryGetValue("-" + inputB[j].ToString(), out score1);
                    dict.TryGetValue(inputA[i].ToString() + "-", out score2);
                    if (i == 0)
                        scoreMatrix[i, j] = score1;
                    else if (j == 0)
                        scoreMatrix[i, j] = score2;
                    else
                        scoreMatrix[i, j] = Math.Max(scoreMatrix[i - 1, j - 1] + score, Math.Max(scoreMatrix[i - 1, j] + score1, scoreMatrix[i, j - 1] + score2));
                }
            }
            for (int i = 0; i < inputA.Length; i++)
            {
                for (int j = 0; j < inputB.Length; j++)
                {
                    Console.Write(scoreMatrix[i, j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Alignment Score : " + scoreMatrix[inputA.Length - 1, inputB.Length - 1]);
            printAllAlignments(realInputA, realInputB);
            Console.Read();
        }
        static void printAllAlignments(string inputA, string inputB)
        {
            int minLen = Math.Max(inputA.Length, inputB.Length);
            int maxLen = inputA.Replace("-", "").Length + inputB.Replace("-", "").Length;
            Dictionary<string, int> solutions = new Dictionary<string, int>();
            solutions = prepareStartSequences(inputA, inputB, minLen, solutions);
            addLongerSequences(inputA, minLen, maxLen, solutions);
            var solutionsOrdered = solutions.OrderByDescending(x => x.Value);
            int maxScore = solutionsOrdered.First().Value;
            foreach (var sol in solutionsOrdered.Where(x => x.Value == maxScore))
            {
                Console.WriteLine("{0}\n{1}\tScore: {2}\n\n", sol.Key.Split('|')[0], sol.Key.Split('|')[1], sol.Value);
            }
        }
        private static void addLongerSequences(string inputA, int minLen, int maxLen, Dictionary<string, int> solutions)
        {
            for (int l = minLen + 1; l <= maxLen; l++)
            {
                List<Tuple<string, string>> currCombs = solutions
                    .Where(x => x.Key.Length / 2 + 1 == l)
                    .Select(x => x.Key.Split('|'))
                    .Select(x => new Tuple<string, string>(x[0], x[1]))
                    .ToList();
                foreach (var comb in currCombs)
                {
                    for (int idxA = 0; idxA <= inputA.Length; idxA++)
                    {
                        for (int idxB = 0; idxB <= inputA.Length; idxB++)
                        {
                            string cA = comb.Item1.Insert(idxA, "-");
                            string cB = comb.Item2.Insert(idxB, "-");
                            int score = getScore(cA, cB);
                            string key = cA + "|" + cB;
                            if (!solutions.ContainsKey(key) && score > int.MinValue)
                            {
                                solutions.Add(key, score);
                            }
                        }
                    }
                }
            }
        }
        private static Dictionary<string, int> prepareStartSequences(string inputA, string inputB, int minLen, Dictionary<string, int> solutions)
        {
            if (inputA.Length == inputB.Length)
                solutions.Add(inputA + "|" + inputB, getScore(inputA, inputB));
            else
            {
                string shorter = inputA.Length > inputB.Length ? inputB : inputA;
                string longer = inputA.Length > inputB.Length ? inputA : inputB;
                int shortLen = shorter.Length;
                List<string> combinations = new List<string>();
                combinations.Add(shorter);
                while (shortLen < minLen)
                {
                    List<string> tmpCombinations = new List<string>();
                    foreach (string str in combinations)
                    {
                        for (int i = 0; i <= shortLen; i++)
                        {
                            tmpCombinations.Add(str.Insert(i, "-"));
                        }
                    }
                    combinations = tmpCombinations.Distinct().ToList();
                    shortLen++;
                }
                foreach (var comb in combinations)
                {
                    if (inputA.Length > inputB.Length)
                    {
                        solutions.Add(longer + "|" + comb, getScore(longer, comb));
                    }
                    else
                    {
                        solutions.Add(comb + "|" + longer, getScore(comb, longer));
                    }
                }
            }
            solutions = solutions.Where(x => x.Value != int.MinValue).ToDictionary(x => x.Key, y => y.Value);
            return solutions;
        }
        static int getScore(string inputA, string inputB)
        {
            int result = 0;
            for (int i = 0; i < inputA.Length; i++)
            {
                string key = inputA[i].ToString() + inputB[i].ToString();
                if (key == "--") return int.MinValue;
                result += dict.ContainsKey(key) ? dict[key] : 0;
            }
            return result;
        }
