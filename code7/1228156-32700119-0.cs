    public class MyModel
    {
        public int SelectedId { get; set; }
        public IList<SelectListItem> AllItems { get; set; }
    
        public MyModel()
        {
            AllItems = new List<SelectListItem>();
        }
    }
