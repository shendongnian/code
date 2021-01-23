    public class TestObj
    {
    	public int nodeId { get; set; }
    }
    
    public class MapApiController : UmbracoApiController
    {
    
    	[System.Web.Http.HttpPost]
    	public void GetMapMarkers(TestObj t)
    	{
    		// ..
    	}
    }
