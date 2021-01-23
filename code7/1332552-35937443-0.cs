    class Program
    {
    	static void Main()
    	{
    		string json =
    			"{ \"AccountId\": 12345665555, \"InvoicId\": 1235, \"Addresses\": [[\"10 Watkin , , , , , Northampton, Northamptonshire\"], [\"12 Spencer Terrace, , , , , Northampton, Northamptonshire\"], [\"18 Watkin , , , , , Northampton, Northamptonshire\"], [\"22 Watkin , , , , , Northampton, Northamptonshire\"]] }";
    
    		RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
    
    		foreach (List<string> address in root.Addresses)
    		{
    			string[] addressLines = address[0].Split(new char[] {','});
    
    			AddressResult addressResult = new AddressResult()
    			{
    				Line1 = addressLines[0],
    				Line2 = addressLines[1]
    				//...
    			};
    		}
    
    	}
    
    	private class AddressResult
    	{
    		public string Line1 { get; set; }
    		public string Line2 { get; set; }
    		public string Line3 { get; set; }
    		public string Locality { get; set; }
    		public string Town { get; set; }
    		public string County { get; set; }
    
    	}
    
    	public class RootObject
    	{
    		public long AccountId { get; set; }
    		public int InvoicId { get; set; }
    		public List<List<string>> Addresses { get; set; }
    	}
    }
