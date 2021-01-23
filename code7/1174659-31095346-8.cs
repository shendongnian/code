    public class Test
    {
    	private string _lastName = "LName";
    	private string _firstName = "FName";
    	public string Name { get{
    		return _lastName + " " + _firstName;
    	} }
    
    	public string GetName()
    	{
    		return _lastName + " " + _firstName;
    	}
    }
    class Program
    {
    	static void Main(string[] args)
    	{
    		var test = new Test();
    		Console.WriteLine(test.Name);
    		Console.WriteLine(DateTime.Today.DayOfWeek);
    	}
    }
