    public class SitecoreItem : SearchResultItem
    {
    [IndexField("title")]        
    public string Title { get; set; }
    
    [IndexField("__smallcreateddate")]
    public DateTime PublishDate { get; set; }
    
    [IndexField("has_presentation")]
    public bool HasPresentation { get; set; }
    
    }
