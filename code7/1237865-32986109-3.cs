    public class LogModelVM
    {
      public int SelectedCustomer { get; set; }
      public IEnumerable<SelectListItem> CustomerList { get; set; } // suggested name change
      public string Message { get; set; } // for the message search box?
      public IPagedList<NowasteWebPortalMVC.Models.LogModel> Logs { get; set; }
      .... // add properties for sortorder etc
    }
