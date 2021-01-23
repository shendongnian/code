	public class SecurityAnswerVM
	{
		[Required(ErrorMessage="Please select a question")]
		[Display(Name = "Question")]
        public int? QuestionID { get; set; }
        [Required(ErrorMessage = "Please enter an answer")]
        public string Answer { get; set; }
	}
	public class SecurityLoginVM
	{
		public SelectList QuestionList { get; set; }
		public List<SecurityAnswerVM> SelectedQuestions { get; set; }
	}
