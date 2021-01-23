    public class CreateCustomerVM
    {
      public string Name { set;get;}
      public List<SelectListItem> IntermediaryOptions {set;get;}
      public string IntermediaryRequired {set;get;}
    
      public CreateCustomerVM()
      {
        this.IntermediaryOptions =new List<SelectListItem>() 
      }
    }
