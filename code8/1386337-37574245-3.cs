    public static List<List<object>> PartitionByTypes(List<object> values) {
        var batches = new List<List<object>>();
        object prev = null;
        var batch = new List<object>();
        foreach (var value in values) {
            if (prev != null && prev.GetType() != value.GetType()) {
                batches.Add(batch);
                batch = new List<object>();
            }
            batch.Add(value);
            prev = value;
        }
        if (batch.Count > 0)
            batches.Add(batch);
        return batches;
    }
