    public static int GetFreshId(this IEnumerable<int> existingIds)
    {
        if (existingIds == null) {
            throw new ArgumentNullException(nameof(existingIds));
        }
        if (!existingIds.Any()){
            return int.MinValue;
        }
        var lastId = existingIds.Max();
        if (lastId == Int.MaxValue){
            throw new ApplicationException("Sorry there are no more int available. Consider switching to int64.");
        }
        return lastId+1;
    }
