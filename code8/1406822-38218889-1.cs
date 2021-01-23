     [Serializable]
    public class QuestionnairModel
    {
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public List<QuestionnairOptionModel> QuestionnairOption { get; set; }
    }
    [Serializable]
    public class QuestionnairOptionModel
    {
        public long OptionId { get; set; }
        public string OptionString { get; set; }
        public bool OptionControl1 { get; set; }
        public string OptionControl2 { get; set; }
    }
