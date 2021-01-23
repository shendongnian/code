    using System.Xml.Serialization;
    public class Question
    {
        [XmlElement("QuestionText")]
        public string QuestionText {get;set;}
        [XmlElement("Answer")]
        public string[] Answer {get;set;}
        [XmlElement("CorrectAnswer")]
        public string CorrectAnswer {get;set;}
    }
    [XmlRoot("Questions")
    public class Questions
    {
        [XmlElement("Question")]
        public Question[] Question {get;set;}
    }
