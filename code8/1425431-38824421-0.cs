    public static List<T[]> SubsetSums<T>(T[] items, int target, Func<T, int> amountGetter)
        {
            Stack<T> unusedItems = new Stack<T>(items.OrderByDescending(amountGetter));
            Stack<T> usedItems = new Stack<T>();
            List<T[]> results = new List<T[]>();
            SubsetSumsRec(unusedItems, usedItems, target, results, amountGetter);
            return results;
        }
        public static void SubsetSumsRec<T>(Stack<T> unusedItems, Stack<T> usedItems, int targetSum, List<T[]> results, Func<T,int> amountGetter)
        {
            if (targetSum == 0)
                results.Add(usedItems.ToArray());
            if (targetSum < 0 || unusedItems.Count == 0)
                return;
            var item = unusedItems.Pop();
            int currentAmount = amountGetter(item);
            if (targetSum >= currentAmount)
            {
                // case 1: use current element
                usedItems.Push(item);
                SubsetSumsRec(unusedItems, usedItems, targetSum - currentAmount, results, amountGetter);
                usedItems.Pop();
                // case 2: skip current element
                SubsetSumsRec(unusedItems, usedItems, targetSum, results, amountGetter);
            }
            unusedItems.Push(item);
        }
