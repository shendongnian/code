    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    void Main()
    {
    	var responseString = "{\"name1\":{\"id\":123456789,\"name\":\"nickname\",\"profileIconId\":1114,\"summonerLevel\":30},\"name2\":{\"id\":123456789,\"name\":\"nickname\",\"profileIconId\":948,\"summonerLevel\":30}}";
    	JObject data = JsonConvert.DeserializeObject<JObject>(responseString);
	    var names = new List<Name>();
	
	    foreach (var x in data) names.Add(x.Value.ToObject<Name>());
	    names.Dump();
    }
    
    public class Name
    {
    	public int id { get; set; }
    	public string name { get; set; }
    	public int profileIconId { get; set; }
    	public int summonerLevel { get; set; }
    }
