    List<Model> list = new List<Model>();
    
    JArray array = JArray.Parse(json);
    foreach (JObject item in array)
    {
    	list.Add(new Model() {
    		Exp = item.Value<DateTime>("_exp"),
    		Id = item.Value<int>("_id"),
    		Val = item.Value<string>("$val")
    	});
    }
    public class Model
    {
    	public DateTime Exp { get; set; }
    	public int Id { get; set; }
    	public string Val { get; set ;}
    }
