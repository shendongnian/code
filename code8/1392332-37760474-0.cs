    public class StaticCache
    {
    
    	private static List<ImageHighlight> _images = null;
    
    	public static void LoadStaticCache()
    	{
    		// Get images - cache using a static member variable
    		using (var datacontext = new MHRDataContext())
    		{
    			_images = datacontext.ImageHighlights.ToList();
    		}
    	}
    	public static List<ImageHighlight> GetHighlightImages()
    	{
    		return _images;
    	}
    }
