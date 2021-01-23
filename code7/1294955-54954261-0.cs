    using System.ServiceModel.Channels;
    
    namespace Site.Api
    {
    	
    	public class RawContentTypeMapper : WebContentTypeMapper
    	{
    		public override WebContentFormat GetMessageFormatForContentType(string contentType)
    		{
    			// this allows us to accept XML (or JSON now) as the contentType but still treat it as Raw
    			// Raw means we can accept a Stream and do things with that (rather than build classes to accept instead)
    			if (
    				contentType.Contains("text/xml") || contentType.Contains("application/xml")
    				|| contentType.Contains("text/json") || contentType.Contains("application/json")
    				)
    			{
    				return WebContentFormat.Raw;
    			}
    			return WebContentFormat.Default;
    		}
    	}
    }
