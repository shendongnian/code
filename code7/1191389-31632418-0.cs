    public class NewThreatVM
    {
      public string Description { get; set; } // add validation attributes as required
      public List<int> SelectedSecurityEvents { get; set; }
      public SelectList SecurityEventList { get; set; } // or IEnumerable<SelectListItem>
    }
