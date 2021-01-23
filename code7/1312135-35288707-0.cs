    public abstract class OverviewItems
    {
    	public abstract string GetTitle();
    }	
    
    public class Videos : OverviewItems
    {
    	public string videoTitle { get; set; }
    	public override string GetTitle()
    	{
    		return videoTitle;
    
    	}
    }
    
    public class Images : OverviewItems
    {
    	public string imagesTitle { get; set; }
    	public override string GetTitle()
    	{
    		return imagesTitle;
    
    	}
    }
     IList<OverviewItems> items = new List<OverviewItems>();
    
     var images = db.Images.Where ...;
     var videos = db.Videos.Where...;
    
    items.add(images);
    items.add(videos);
        
    var filtredItems = items.where(i=>i.GetTitle() == "SomeTitle");
