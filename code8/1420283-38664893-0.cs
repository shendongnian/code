    public class JsonDateFormatter : JsonMediaTypeFormatter
    {
    	public override System.Threading.Tasks.Task<Object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger, CancellationToken cancellationToken)
    	{
    	    //Do date formatting here
    	}
    
    	public override bool CanReadType(Type type)
    	{
    	    if (type == typeof(DateTime))
    		    return true;
    	    return false;
    	}
    }
