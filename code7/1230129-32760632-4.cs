    public class BaseHeaderFooterItem
    {
      public string Title { get; set; }
      public string EnTitle { get; set; }
      public HyperLink Link { get; set; }
      public int Level { get; set; }
      public HyperLink MobileLink { get; set; }
      // here you can add instances of BaseHeaderFooterItem and any inherits type
      public List<BaseHeaderFooterItem> Descendants { get; set; } 
    }
