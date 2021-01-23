    public class SampleModel
    {
        public string SelectedColorId { get; set; }
        public IList<SelectListItem> AvailableColors { get; set; }
    
        public SampleModel()
        {
            AvailableColors = new List<SelectListItem>();
        }
    }
