    public class MyViewModel
    {
      [DropDownList(nameof(Planets))]
      public string PlanetId{ get; set; }
      public IEnumerable<SelectListItem> Planets { get; set; }
    
      [DropDownList(nameof(Cars))]
      public string CarId{ get; set; }
      public IEnumerable<SelectListItem> Cars { get; set; }
    }
