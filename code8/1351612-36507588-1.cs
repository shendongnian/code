    public class DocumentCategoryModel : IDocumentCategoryTree
    {
    	public DocumentCategoryModel()
    	{
    		SubCategories = new List<IDocumentCategoryTree>();
    	}
    
    	public int ID { get; set; }
    	
    	[JsonConverter(typeof(DocumentCategoryTreeConverter)]
    	public ICollection<IDocumentCategoryTree> SubCategories { get; set; }
    }
    
    public class DocumentCategoryTreeConverter : JsonConverter
    {
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		// Todo if desired
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		return serializer.Deserialize<TestTree>(reader);
    	}
    
    	public override bool CanConvert(Type objectType)
    	{
    		// Todo
    	}
    }
