    public interface IBaseHeaderFooterItem
    {
        string Title { get; set; }
        string EnTitle { get; set; }
        public HyperLink Link { get; set; }
        int Level { get; set; }
        HyperLink MobileLink { get; set; }
    }
    public abstract class BaseHeaderFooterItem<T> : IBaseHeaderFooterItem 
                                                    where T : IBaseHeaderFooterItem
    {
        public List<T> Descendants { get; set; }
         public abstract string Title { get; set; }
         public abstract string EnTitle { get; set; }
         public abstract HyperLink Link { get; set; }
         public abstract int Level { get; set; }
         public abstract HyperLink MobileLink { get; set; }
    }
