    public class QuestionModel
    {
        public int QuestionID { get; set; }
    	
        public string QuestionText { get; set; }
    
        /// <summary>
        /// Gets or sets the selected items. Purely a helper List to display check boxes for the user
        /// </summary>
        /// <value>
        /// The selected items.
        /// </value>
        [Display(Name = "Items", ResourceType = typeof(Domain.Resources.Question))]
        public IEnumerable<SelectListItem> SelectedItems { get; set; }
    
        /// <summary>
        /// Gets or sets the selected ids. Populated by the user, when he checks / unchecks items. Later translated into QuestionItems
        /// </summary>
        /// <value>
        /// The selected ids.
        /// </value>
        public int[] SelectedIds { get; set; }
    }
