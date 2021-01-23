        static void Main()
        {
            var columns = 6;
            var groupSize = 2;
            var groups = GetGroups(columns, groupSize).ToArray();
            var groupCurrentIndex = Enumerable.Range(0, groups.Length).ToDictionary(i => i, i => 0);
            var maxIndex = groupSize - 1;
            while (true)
            {
                var combination = groups.Select((g, i) => g[groupCurrentIndex[i]]);
                PrintCombination(combination);
                var incrementedGroupIndex = false;
                for (var i = groups.Length - 1; i > 0; i--)
                {
                    if (groupCurrentIndex[i] != maxIndex)
                    {
                        groupCurrentIndex[i]++;
                        incrementedGroupIndex = true;
                        break;
                    }
                    if (groupCurrentIndex[i] == maxIndex && groupCurrentIndex[i - 1] != maxIndex)
                    {
                        groupCurrentIndex[i-1]++;
                        incrementedGroupIndex = true;
                        for (var j = i; j < groups.Length; j++)
                        {
                            groupCurrentIndex[j] = 0;
                        }
                        break;
                    }
                }
                if (!incrementedGroupIndex)
                {
                    break;
                }
            }
            Console.ReadLine();
        }
        private static IEnumerable<int[]> GetGroups(int columns, int groupSize)
        {
            for (var startIndex = 0; startIndex < columns; startIndex = startIndex + groupSize)
            {
                yield return Enumerable.Range(startIndex, groupSize).ToArray();
            }
        }
        private static void PrintCombination(IEnumerable<int> combination)
        {
            Console.WriteLine(string.Join(" - ", combination));
        }
