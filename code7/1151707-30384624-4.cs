    var dict = "[{\"key\":\"60236\",\"value\":\"1\"},{\"key\":\"60235\",\"value\":\"gdsfgdfsg\"},{\"key\":\"60237\",\"value\":\"1\"}]";
	var output = JsonConvert.DeserializeObject<List<Temp>>(dict);
	var dictionary = output.ToDictionary(x => x.Key, y => y.Value);
    public class Temp
    {
    	public int Key { get; set; }
    	public string Value { get; set; }
    }
