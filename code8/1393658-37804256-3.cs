    public class ModelVariables
    {
        [Required(ErrorMessage = "...")]
        public string SelectedValue { get; set; }
        public List<string> Options { get; set; }
    }
