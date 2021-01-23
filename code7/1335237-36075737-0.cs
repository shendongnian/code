    public class myclass
    {
    	[JsonProperty("name")]
    	public string Name {get;set;]
    }
    [WebMethod(EnableSession = true)]
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public List<ProductDetail> getAllProductsNearMeJson(MyClass ProductRequest)
    {
      //do your stuff here and return a List<T>
    }
