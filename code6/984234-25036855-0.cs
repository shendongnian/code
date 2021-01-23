    public class MyViewModel
    {
        public string ValueId { get; set; }
        public IEnumerable<SelectListItem> Values 
        { 
            get 
            {
                return new[]
                {
                    new SelectListItem { Value = "1", Text = "item 1" },
                    new SelectListItem { Value = "2", Text = "item 2" },
                    new SelectListItem { Value = "3", Text = "item 3" },
                };
            } 
        }
    
        public string NewValue { get; set; }
    }
