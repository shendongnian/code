    public class DynamicJsonMediaTypeFormatter : JsonMediaTypeFormatter
    { 
    public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, System.Net.Http.HttpRequestMessage request, System.Net.Http.Headers.MediaTypeHeaderValue mediaType)
    {
    // shown is getting the current formatter, but you can return an instance you prefer
      var formatter = base.GetPerRequestFormatterInstance(type, request, mediaType) as JsonMediaTypeFormatter; 
    	 
    // Here I had more code to get the resolver based on request, skipped
      ((JsonMediaTypeFormatter)formatter).SerializerSettings.ContractResolver = <YourContractResolverInstance>;
    	return formatter;
    }
    }
