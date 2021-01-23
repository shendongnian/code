    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Data
    {
    	public Dictionary<string, List<User>> Objects { get; set; }
    }
    string jsonString = '...';
	dynamic jsonObject = JsonConvert.DeserializeObject(jsonString);
	
    // could have made use of LINQ to shorten this bit of code 
    // but unfortunately dynamic doesn't play well with extension methods
	var data = new Data { Objects = new Dictionary<string, List<User>>() };
	foreach (var obj in jsonObject.data) 
		data.Objects[obj.Name] = obj.Value.ToObject<List<User>>();
    // now you have everything in `data` instance.
