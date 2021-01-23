    public class Questions
    {
        [XmlElement("Question")]
        public List<Question> QuestionList { get; set; } = new List<Question>();
    }
    public class Question
    {
        [XmlAttribute("text")]
        public string Text { get; set; }
        public string answerA { get; set; }
        public string answerB { get; set; }
        public string answerC { get; set; }
        public string answerD { get; set; }
        public string correctAnswer { get; set; }
    }
