     public class ContainsADropdownViewModel {
        public CrimsDetailModel Selected { get; set; }
        // to be read in controller
        public IEnumerable<CrimsDetailModel> RawOptions { get; set; }
        // generate SelectListItems to be used with DropDownListFor()
        public IEnumerable<SelectListItem> Options { get { 
            foreach (var detail in RawOptions) {
                yield return new SelectListItem {
                    Value = detail.ID, // something unique
                    Text =  detail.Desc, // shown to User
                    Selected = detail == Selected // stays selected after roundtrip
                };
            }
        }}
    }
