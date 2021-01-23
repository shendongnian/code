    private static void Main(string[] args)
    {
    	Dictionary<int, BatchData> dic = new Dictionary<int, BatchData>();
    
    	dic.Add(1, new BatchData() { batchNumber = "x" });
    	dic.Add(2, new BatchData() { batchNumber = "y" });
    	dic.Add(3, new BatchData() { batchNumber = "z" });
    
    	bool contain = dic.Contains(new KeyValuePair<int, BatchData>(100, new BatchData()
    	{
    		batchNumber = "z"
    	}), new BatchDataComparer());
    
    	Console.ReadKey();
    }
    
    public class BatchData
    {
    	public string batchNumber { get; set; }
    	public string processDate { get; set; }
    	public int TotalRecords { get; set; }
    	public int SuccessCount { get; set; }
    }
    
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
