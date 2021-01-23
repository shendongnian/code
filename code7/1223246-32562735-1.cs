    public interface ISitecoreItem
    {
        [SitecoreChildren(InferType = true)]
        IEnumerable<ISitecoreItem> Children { get; set; }
    }    
    [SitecoreType]
    public class News : ISitecoreItem
    {
        public string Title { get; set; }
        public virtual IEnumerable<ISitecoreItem> Children { get; set; }
    }
    
    private static IEnumerable<T> GetChildren<T>(this Item parentItem) where T : ISitecoreItem
    {
        var parentModel = item.GlassCast<ISitecoreItem>();
        return parentModel.Children.OfType<T>();
    }
    //usage:
    var newsItems = parentItem.GetChildren<News>();
