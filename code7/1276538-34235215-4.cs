    public abstract class BaseVM
    {
      [Required(ErrorMessage = "Please select an item")] // add other display and validation attributes as necessary
      public int SelectedItem { get; set; } // or string?
      public IEnumerable<SelectListItem> SelectListModel { get; set; }
      .... // other common properties
    }
