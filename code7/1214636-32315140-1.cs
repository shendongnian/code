    namespace PlataformaTest.Models
    {
        public class AnswerModel
        {
            public int Id { get; set; }
    
            public string UserId { get; set; }
    
            [ForeignKey("OptionModel"), Column(Order = 0)]
            public int QuestionId { get; set; }
    
            [ForeignKey("OptionModel"), Column(Order = 1)]
            public int OptionId { get; set; }
    
            [JsonIgnore]
            public virtual OptionModel OptionModel { get; set; }
        }
    }
