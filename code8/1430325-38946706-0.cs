    public class CreateSiteVm
    {
      [Required] 
      public string Name { set;get;}
      [Required] 
      public string Description { set;get;}
      [Required] 
      public string Tags { set;get;}
      [Required] 
      public int TypeMenuId { set;get;}
      public List<SelectListItem> TypeMenus { set;get;}
    }
