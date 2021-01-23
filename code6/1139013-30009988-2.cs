    public static IEnumerable<List<int>> findSubsetsWithLengthKAndSumS2(Tuple<int, int> ks, List<int> set, List<int> subSet, List<int> subSetIndex)
        {
            if (ks.Item1 == 0 && ks.Item2 == 0)
            {
                var res = new List<List<int>>();
                res.Add(subSetIndex);
                return res;
            }
            else if (ks.Item1 > 0 && ks.Item2 > 0)
            {
                var res = set.Select((x, i) =>
                {
                    var newSubset = subSet.Select(y => y).ToList();
                    newSubset.Add(x);
                    var newSubsetIndex = subSetIndex.Select(y => y).ToList();
                    newSubsetIndex.Add(i);
                    var newSet = set.Skip(i).ToList();
                    return findSubsetsWithLengthKAndSumS2(Tuple.Create(ks.Item1 - 1, ks.Item2 - x), newSet, newSubset, newSubsetIndex).ToList();
                }
                ).SelectMany(x => x).ToList();
                return res;
            }
            else
                return new List<List<int>>();
        }
    ...
                var res = findSubsetsWithLengthKAndSumS2(Tuple.Create(2, 293), numbers.ToList(), new List<int>(), new List<int>());
