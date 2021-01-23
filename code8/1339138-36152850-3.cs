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
            var result = Environment.NewLine;
    
            if(tenantID = 1)
    			result "body{ background-color: black !important;}"
    		else
    			result "body{ background-color: pink !important;}"
    
    		result += Environment.NewLine;
    
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            var content = encoding.GetBytes(result);
    
            Response.ContentType = contentType;
    
            return new FileContentResult(result, contentType);
        }
    }
