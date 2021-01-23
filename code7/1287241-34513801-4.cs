    public class MedicineMasterVm
    {      
      public string[] SelectedSuppliers { get; set; }  
      public IEnumerable<SelectListItem> Suppliers { get; set; }    
     
      //Add Other needed properties here
      public string Med_Name { get; set; }
      public string Med_code { get; set; }
    }
