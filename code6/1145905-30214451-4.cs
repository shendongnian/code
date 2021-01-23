    [DataContract]
    public class Evaluation
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
    
        [DataMember(Name = "avg")]
        public string Average { get; set; }
    
        [DataMember(Name = "median")]
        public string Median { get; set; }
    
        [DataMember(Name = "teacherID")]
        public int TeacherId { get; set; }
    
        [DataMember(Name = "evalType")]
        public int EvaluationType { get; set; }
    }
