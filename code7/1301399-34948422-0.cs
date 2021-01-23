     public class Test
    {
        public int LowerAgeLimit { get; set; }
        public List<SelectListItem> Ages
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{Text="1", Value="1"},
                    new SelectListItem{Text="2", Value="2"},
                    new SelectListItem{Text="3", Value="3"},
                    new SelectListItem{Text="4", Value="4"}
                };
            }
        }
    }
