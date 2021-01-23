    public class Question
    {
        [XmlElement("QuestionText")]
        public string QuestionText {get;set;}
        [XmlElement("Ans1")]
        public string Answer1 {get;set;}
        [XmlElement("Ans2")]
        public string Answer2 {get;set;}
        [XmlElement("Ans3")]
        public string Answer3 {get;set;}
        [XmlElement("Ans4")]
        public string Answer4 {get;set;}
        [XmlElement("CorrectAnswer")]
        public string CorrectAnswer {get;set;}
    }
    [XmlRoot("Questions")
    public class Questions
    {
        [XmlElement("Question")]
        public Question[] Question {get;set;}
    }
