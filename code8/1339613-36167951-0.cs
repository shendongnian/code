    class Program
    {
        static void Main(string[] args)
        {
            string test1 = "fox";
            string test2 = "The quick";
            string test3 = "The quick fox";
            string test4 = "The quick fox says";
            string test5 = "The quick fox says hello";
            var splittest1 = test1.Split(' ');
            var splittest2 = test2.Split(' ');
            var splittest3 = test3.Split(' ');
            var splittest4 = test4.Split(' ');
            var splittest5 = test5.Split(' ');
            var ans1 = getcombinations(splittest1);
            var ans2 = getcombinations(splittest2);
            var ans3 = getcombinations(splittest3);
            var ans4 = getcombinations(splittest4);
            var ans5 = getcombinations(splittest5);
        }
        static List<string> getcombinations(string[] splittest)
        {
            var combos = new List<string>();
            var numspaces = splittest.Count() - 1;
            if (numspaces == 1)
            {
                var addcombos = AddTwoStrings(splittest[0], splittest[1]);
                var withSpacesCurrent = addcombos.Item1;
                var noSpacesCurrent = addcombos.Item2;
                combos.Add(withSpacesCurrent);
                combos.Add(noSpacesCurrent);
            }
            else if (numspaces == 0)
            {
                combos.Add(splittest[0]);
            }
            else
            {
                var addcombos = AddTwoStrings(splittest[0], splittest[1]);
                var withSpacesCurrent = addcombos.Item1;
                var noSpacesCurrent = addcombos.Item2;
                var futureCombos = getcombinations(splittest.Skip(2).ToArray());
                foreach (var futureCombo in futureCombos)
                {
                    var addFutureCombos = AddTwoStrings(withSpacesCurrent, futureCombo);
                    var addFutureCombosNoSpaces = AddTwoStrings(noSpacesCurrent, futureCombo);
                    var combo1 = addFutureCombos.Item1;
                    var combo2 = addFutureCombos.Item2;
                    var combo3 = addFutureCombosNoSpaces.Item1;
                    var combo4 = addFutureCombosNoSpaces.Item2;
                    combos.Add(combo1);
                    combos.Add(combo2);
                    combos.Add(combo3);
                    combos.Add(combo4);
                }
            }
            
            
            return combos;
        }
        static Tuple<string, string> AddTwoStrings(string a, string b)
        {
            return Tuple.Create(a + " " + b, a + b);
        }
    }
    }
