    public static List<List<object>> LinqPartitionByTypes(List<object> values)
    {
        var batches = new List<List<object>>();
        while (true)
        {
             object prev = null;
             var batch = values.Skip(batches.Sum(c => c.Count)).TakeWhile(c => {
                  var result = prev == null || prev.GetType() == c.GetType();
                  prev = c;
                  return result;
             }).ToList();
             if (batch.Count == 0)
                  break;
             batches.Add(batch);
         }
         return batches;
    }
