    public class WebApiConfig
    {
    	public static HttpConfiguration Register()
    	{
    		var config = new HttpConfiguration();
            // This next line could stay if you want xml formatting
    		config.Formatters.Remove(config.Formatters.XmlFormatter);
    		
    		// This next commented out line was causing the problem
    		//var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
    		
    		// This next line was the solution
    		var jsonFormatter = config.Formatters.JsonFormatter;
    		jsonFormatter.UseDataContractJsonSerializer = false; // defaults to false, but no harm done
    		jsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
    		jsonFormatter.SerializerSettings.Formatting = Formatting.None;
    		jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();           
    		
    		// remaining irrelevant code commented out
    		return config;
    	}
    }
