    public class QuestionDataViewModel
    {
        public List<QuestionData> Data { get; set; }
    }
    public class QuestionData
    {
        public string AreaName { get; set; }
        public List<Question> QuestionList { get; set; }
    }
    public class Question
    {
        public int StnAssureQuestionId { get; set; }
        public int Score { get; set; }
        public IEnumerable<SelectListItem> Scores { get; set; }
        public List<Comment> Comments { get; set; }
    }
