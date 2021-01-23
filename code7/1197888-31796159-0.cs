    public class CreateOrderVM
    {
      public List<SelectListItem> Modes {set;get;}
      public string SelectedMode {set;get;}
    
      public CreateOrderVM()
      {
        this.Modes=new List<SelectListItem>();
      }
    }
