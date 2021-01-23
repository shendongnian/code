    var dict = "[{\"key\":\"60236\",\"value\":\"1\"},{\"key\":\"60235\",\"value\":\"gdsfgdfsg\"},{\"key\":\"60237\",\"value\":\"1\"}]";
	var output = JsonConvert.DeserializeObject<List<Temp>>(dict);
	var dictionary = new Dictionary<int,string>();
	
	foreach(var item in output)
	{
        dictionary.Add(item.Key, item.Value);
	}
    public class Temp
    {
    	public int Key { get; set; }
    	public string Value { get; set; }
    }
