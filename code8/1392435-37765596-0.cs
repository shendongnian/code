    public static Dictionary<T, int> Distribute<T>(Dictionary<T, int> occurMap, int slots)
    {
        if(slots < occurMap.Count)
            throw new ArgumentException("Not enough slots");
        var freeSlots = slots - occurMap.Count;
        var total = occurMap.Sum(x => x.Value);
        var distMap = new Dictionary<T, int>();
        var keysByProb = new Queue<T>();
        foreach (var pair in occurMap.OrderByDescending(c => (double)c.Value / total))
        {
            var probability = (double)pair.Value / total;
            var assignedSlots = probability * freeSlots;
            distMap[pair.Key] = 1+ (int)Math.Floor(assignedSlots);
            keysByProb.Enqueue(pair.Key);
        }
        var left = slots - distMap.Select(x => x.Value).Sum();
        while (left > 0) {
            distMap[keysByProb.Dequeue()]++;
            left--;
        }
        Debug.Assert(distMap.Select(x => x.Value).Sum() == slots);
        return distMap;
    }
