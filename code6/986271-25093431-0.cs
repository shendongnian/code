    public class OptionGroup
    {
      public string OptionType { get; set; } // add get/set
      public IEnumerable<SelectListItem> Options { get; set; }
      public string SelectedOption { get; set; } // add get/set
    }
