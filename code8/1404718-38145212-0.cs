    public class Question
    {
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; } 
        public string AnswerText { get; set; }
    }
    public class Answer
    {
        public string ID { get; set; }
        public string AnswerText { get; set; }
    }
