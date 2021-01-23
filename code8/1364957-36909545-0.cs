    public class Datum
    {
    	public string id { get; set; }
    	public string Name { get; set; }
    }
    
    public class RootObject
    {
    	public List<Datum> Data { get; set; }
    } 
    
    static void Main()
    {
    	string json = "{   \"Data\":[ { \"id\":\"1\", \"Name\":\"Sachin\" }, { \"id\":\"2\", \"Name\":\"Rahul\" }, { \"id\":\"3\", \"Name\":\"Sovrav\" } ] }";
    
    	RootObject ro = JsonConvert.DeserializeObject<RootObject>(json);
    
    	string newJson = JsonConvert.SerializeObject(ro.Data);
    }
