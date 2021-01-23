    public class BaseHeaderFooterItem<T>
                 where T : BaseHeaderFooterItem<T>
    {
      public string Title { get; set; }
      public string EnTitle { get; set; }
      public HyperLink Link { get; set; }
      public int Level { get; set; }
      public HyperLink MobileLink { get; set; }
      // only T types
      public List<T> Descendants { get; set; }
    }
    var list = new List<BaseHeaderFooterItem<ChildType>>();
    list.Add(new BaseHeaderFooterItem() {
            Title = "Test"
    		Descendants = new List<ChildType>()
    								 {
    									new ChildHeaderFooterItem() { /* properties */}
    								 }
        });
