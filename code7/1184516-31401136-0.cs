    public class Feedback
    {       
        [Required]
        public int? PreviousID { get; set; }
    
        [Required]
        [Display(Name = "Next ID")]
        public int? NextID { get; set; }
    
        [Required]
        public int ScenarioID { get; set; }
    
        [Display(Name = "Select you scenario")]
        public IEnumerable<SelectListItem> YourScenario { get; set; }
    
        public String DisplayName {
            get 
            { 
                String name = "";
                if (ScenarioID == 1) {
                    name = "SomeName";
                } else {
                    name = "otherName";
                }
    
                return name;
            }
        }
    }
