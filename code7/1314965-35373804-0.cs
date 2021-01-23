    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    
    
     public class DocumentsController : ApiController
    {
    	public IHttpActionResult UnlockAssets (string psd )
    	{
    		var documents = new DocumentRepo();
    		if (!documents.Exists(psd))
    		{
    			return NotFound();
    		}else{
    			documents.unlock(psd)
    			return Ok(product);
    		}
    	}
    }
