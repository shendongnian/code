    void Main()
    {
    	var responseString = "{\"name1\":{\"id\":53829733,\"name\":\"nickname\",\"profileIconId\":1114,\"summonerLevel\":30}}";
    	JObject data = JsonConvert.DeserializeObject<JObject>(responseString);
    	var name = data.First.First.ToObject<Name>();
    	name.Dump();
    }
    
    public class Name
    {
    	public int id { get; set; }
    	public string name { get; set; }
    	public int profileIconId { get; set; }
    	public int summonerLevel { get; set; }
    }
