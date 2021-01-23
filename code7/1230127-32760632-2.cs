    public class BaseHeaderFooterItem<T>
    {
      public string Title { get; set; }
      public string EnTitle { get; set; }
      public HyperLink Link { get; set; }
      public int Level { get; set; }
      public HyperLink MobileLink { get; set; }
      // only T types
      public List<T> Descendants { get; set; }
    }
