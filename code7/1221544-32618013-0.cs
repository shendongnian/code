    public class Nav 
    { 
      public SubNav SubNavItem { get; set; } 
      public List<Nav> SubNavItems { get; set; } 
    } 
    public class SubNav 
    { 
      public string Title { get; set; } 
      public string URL { get; set; } 
      public string Target { get; set; } 
    }
