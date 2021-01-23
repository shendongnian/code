    public class DropDownListTemplate
    {
        public string SelectedValue { get; set; }
        public IEnumerable<SelectListItem> Values { get; set; }
    }
    public class MyViewModel
    {
        [IgnoreMap]
        public DropDownListTemplate Planet { get; set; }
        public string PlanetId
        {
            get { return Planet.SelectedValue; }
            set { Planet.SelectedValue = value; }
        }
    }
