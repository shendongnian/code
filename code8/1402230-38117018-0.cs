    public class VisitorsViewModel
    {
        ....
        [Required(ErrorMessage = "Please select a customer contact")]
        [Display(Name = "Contact Person")]
        public Nullable<System.Guid> CustomerContactID { get; set; }
        public IEnumerable<SelectListItem> CustomerContactList { get; set; } // add this
        .... // add other SelectLists rather than using ViewBag
    }
