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
    
     var images = db.Images.Where(i => i != null && i.Items != null && i.Items.Count() > 0).OrderByDescending(i => i.CreatedOn).Take(take).Skip(skip).ToList();
     var videos = db.Videos.Where(v => v != null && !string.IsNullOrEmpty(v.Watch_id)).OrderByDescending(v => v.CreatedOn).Take(take).Skip(skip).ToList();
    
    items.add(images);
    items.add(videos);
        
    var filtredItems = items.where(i=>i.GetTitle() == "SomeTitle");
