    public partial class ProductionSurvey
    {
        public System.Guid ProductionId { get; set; }
        public System.Guid SurveyId { get; set; }
        public Nullable<int> PercentComplete { get; set; }
        public string CompletedBy { get; set; }
        public string DeliverTo { get; set; }
        public System.Guid SurveyId { get; set; }
        public string JobTitle { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> JobNumber { get; set; }
        public Nullable<System.DateTime> SurveyDate { get; set; }
        public Nullable<System.DateTime> RequiredBy { get; set; }
    }
