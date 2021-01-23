    public class PossibleAnswerVM
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool RequireAdditionalText { get; set; }
    }
    public class QuestionVM
    {
        public int ID { get; set; }
        public string Description { get; set; }
        [Required(ErrorMesage = "Please select an option")]
        public int SelectedAnswer { get; set; }
        public string AdditionalText { get; set; }
        public IEnumerable<PossibleAnswer> PossibleAnswers { get; set; }
    }
