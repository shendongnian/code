    namespace ConsoleApplication1
    {
    	public class TestObj
    	{
    		public string Val { get; set; }
    	}
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var testObj = new TestObj { Val = "Initial instance" };
    
    			Console.WriteLine(testObj.Val);
    
    			AssignNewInstance(testObj);
    
    			Console.WriteLine(testObj.Val);
                // Prints: 
                // 'Initial instance'
                // 'Changed in AssignNewInstance'
                // 'Initial instance'
    		}
    
    		public static void AssignNewInstance(TestObj testObj)
    		{
    			testObj = new TestObj { Val = "Changed in AssignNewInstance" };
                Console.WriteLine(testObj.Val);
    		}
    	}
    }`
