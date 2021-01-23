    private AllButtonVisibility visible = new AllButtonVisibility();
        public AllButtonVisibility Visible
        {
            get { return visible; }
            set 
            { 
                visible = value;
                RaiseChange("Visible");
            }
        }
        public class AllButtonVisibility
        {
            public bool AllButtonVisible { get; set; }
        }
