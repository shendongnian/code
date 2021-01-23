    public static List<decimal> CombinationSumMatches(
        this IEnumerable<IEnumerable<decimal>> lists, 
        decimal target)
    {
        if (lists.Any())
        {
            var firstList = lists.First();
            if (lists.Skip(1).Any())
            {
                foreach (var num in firstList)
                {
                    var newTarget = target - num;
                    var subCombination = lists.Skip(1).CombinationSumMatches(newTarget);
                    if (subCombination != null)
                    {
                        subCombination.Insert(0, num);
                        return subCombination;
                    }
                }
            }
            else
            {
                if (firstList.Contains(target))
                {
                    return new List<decimal> { target };
                }
            }
        }
        return null;
    }
