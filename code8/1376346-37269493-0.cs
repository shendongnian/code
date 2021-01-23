    [DataContract]
    public class QuesAnswer
    {
        [DataMember (Name="Answer")]
        public int Answer { get; set; }
        [DataMember(Name = "QuestionID")]
        public int QuestionID { get; set; } 
    }
