    void Main()
    {
    	List<int> numbers = Enumerable.Range(1,100).ToList();
    	var result = numbers.Sum();
    	Console.WriteLine(result); // Prints 5050
    	List<SomeType> customTypeList = Enumerable.Range(1, 100).Select(x => new SomeType { SomeVal = x}).ToList();
    	var customResult = customTypeList.Sum(n => n.SomeVal);
    	Console.WriteLine(result); // Prints 5050
    }
    
    public class SomeType
    {
    	public int SomeVal { get; set;}
    }
