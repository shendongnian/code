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
