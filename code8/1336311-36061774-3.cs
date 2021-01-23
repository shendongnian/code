    class Program
    {
    	static void Main(string[] args)
    	{
    		var json = "{\"Swagger\":\"2.0\",\"Info\":{\"Title\":\"UberAPI\",\"Description\":\"MoveyourappforwardwiththeUberAPI\",\"Version\":\"1.0.0\"},\"Host\":\"api.uber.com\",\"Schemes\":[\"https\"],\"BasePath\":\"/v1\",\"Produces\":[\"application/json\"]}";
    		var swaggerDocument = JsonConvert.DeserializeObject<SwaggerDocument>(json);
    		
    		var serializer = new YamlDotNet.Serialization.Serializer();
    
    		using (var writer = new StringWriter())
    		{
    			serializer.Serialize(writer, swaggerDocument);
    			var yaml = writer.ToString();
    			Console.WriteLine(yaml);
    		}
    	}
    }
    
    public class Info
    {
    	public string Title { get; set; }
    	public string Description { get; set; }
    	public string Version { get; set; }
    }
    
    public class SwaggerDocument
    {
    	public string Swagger { get; set; }
    	public Info Info { get; set; }
    	public string Host { get; set; }
    	public List<string> Schemes { get; set; }
    	public string BasePath { get; set; }
    	public List<string> Produces { get; set; }
    }
