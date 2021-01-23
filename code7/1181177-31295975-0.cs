    public class CarViewModel
    {
        public SelectList Transmissions
        {
            get
            {
                return new SelectList(new List<SelectListItem>{
                    new SelectListItem {  Value = "Manual"},
                    new SelectListItem {  Value = "Automatic"}
                });                
            }
        }
        public string Transmission { get; set; }
    
    }
