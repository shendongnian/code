    public DoSomethingResult DoSomething()
    {
        var result = new DoSomethingResult();
        //....
    	result.Data = GenerateList();
        result.Count = CalculateCount();
    	return result;
    }
    
    public class DoSomethingResult
    {
    	public List<YourType> Data { get; set; }
    	public int Count { get; set; }
    }
