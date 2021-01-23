      public class SurveyAttributes
    {
        public SurveyAttributes()
        {
            SurveyResponse = new List<SurveyResponseAttributes>();
            CampaignResponseAttribute = new List<CampaignResponseAttribute>();
            Answerses = new List<AnswersAttributes>();
            Questions = new List<QuestionsAttributes>();
        }
    
        public string SurveyType { get; set; }
        public string SurveyId { get; set; }
        public string CampaignType { get; set; }
        public string SurveyStatus { get; set; }
        public Questions Questions { get; set; }
    }
    
    public class Questions
    {
      [JsonProperty(PropertyName = "@items")]
      public List<Question> Questions {get;set;}
    }
    
    public class Question
    {
      public string Question { get; set; }
    }
    
    var result = JsonConvert.DeserializeObject<SurveyAttributes>("// your data here");
