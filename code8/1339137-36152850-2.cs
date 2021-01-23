    public class CustomizationController : Controller
    {
        //this will cache cliente side the css file but if the duration expires
        // or the tenantId changes it will be ask for the new file
    	[OutputCache(Duration = 86400, VaryByParam = "tenantID")]
    	public FileResult GetCssForTenant(int? tenantId)
    	{
    		var contentType = "text/css";
            //if teanant id is null return empty css file
            if(!tenantID.HasValue)
                    return new FileContentResult(new byte[0], contentType);
    
    		//load the real css file here <-
    		var result = ...
    		
    		//---
    		//if having problems with the encoding use this ...
    		//System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
    		//var content = encoding.GetBytes(result);
    		//---
    		
    		Response.ContentType = contentType;
    
            return new FileContentResult(result, contentType);
    		//return new FileContentResult(content, contentType);
    	}
    }
