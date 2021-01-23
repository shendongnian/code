    public class BatchDataComparer : IEqualityComparer<KeyValuePair<int, BatchData>>
    {
    	public bool Equals(KeyValuePair<int, BatchData> x, KeyValuePair<int, BatchData> y)
    	{
    		return (x.Value.batchNumber == y.Value.batchNumber);
    	}
    
    	public int GetHashCode(KeyValuePair<int, BatchData> obj)
    	{
    		//or something else what you need
    		return obj.Value.batchNumber.GetHashCode();
    	}
    }
