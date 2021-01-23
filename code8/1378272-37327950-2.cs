    public static IEnumerable<int> CoverAmount(
        int amount, List<int> bills, HashSet<int> used = null)
    {
        if (used == null)
            used = new HashSet<int>();
        if (amount <= 0)
            return Enumerable.Empty<int>();
            
        var overages = new List<Tuple<List<int>, int>>();
        for(int index = 0; index < bills.Count; index++)
        {
            var bill = bills[index];
            if (used.Contains(index))
                continue;
            if (bill > amount)
            {
                overages.Add(Tuple.Create(new List<int> { bill }, bill - amount));
            }
            else if (bill == amount)
            {
                return Enumerable.Repeat(bill, 1);
            }
            else
            {
                used.Add(index);
                var bestSub = CoverAmount(amount - bill, bills, used).ToList();
                used.Remove(index);
                bestSub.Add(bill);
                var sum = bestSub.Sum();
                if (sum == amount)
                {
                    return bestSub;
                }
                if (sum > amount)
                {
                    overages.Add(Tuple.Create(bestSub, sum - amount));
                }
            }
        }
        return overages
            .OrderBy(t => t.Item2)
            .ThenBy(t => t.Item1.Count)
            .FirstOrDefault()?.Item1 ?? Enumerable.Empty<int>();
    
        // OR this if you are not using C# 6
        // var bestOverage = overages
        //    .OrderBy(t => t.Item2)
        //    .ThenBy(t => t.Item1.Count)
        //    .FirstOrDefault();
        // return bestOverage == null ? Enumerable.Empty<int>() : bestOverage.Item1;
    }
