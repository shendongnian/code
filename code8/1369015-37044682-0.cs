    public DoSomethingResult DoSomething()
    {
        var result = new DoSomethingResult();
        //....
    	result.Data = list;
        result.Count = list.Count();
    	return result;
    }
    
    public class DoSomethingResult
    {
    	public List<YourType> Data { get; set; }
    	public int Count { get; set; }
    }
