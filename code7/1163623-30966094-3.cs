    public class SearchBoxViewModel
    {
        [Required]
        [Display(Name = "Search")]
        [Input(Name = "q")]
        public string SearchPhrase { get; set; }
    }
