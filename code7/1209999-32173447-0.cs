    public class BookingVM
    {
      [Display(Name = "Optician")]
      [Required(ErrorMessage = "Please select an optician")]
      public Guid OpticianId { get; set; } // recommend you use int , not Guid
      public IEnumerable<SelectListItem> OpticianList { get; set; }
      .... // other properties to edit in the view
    }
