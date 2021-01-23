    public class AdviceCreateVM
    {
      public int Id { get; set; }
      public string AdviceNo { get; set; }
      public SelectList Companies { get; set; } // change to select list
      public int CompanyID { get; set; } // for binding the the drop down list
    }
