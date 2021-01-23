    public class CreateAnuncios
    {
      public string Title {set;get;}
      public int SelectedSubCategoryId {set;get;}
      public List<SelectListItem> SubCategories {set;get;}
    
      public CreateAnuncios()
      {
        this.SubCategories = new List<SelectListItem>();
      }
    }
