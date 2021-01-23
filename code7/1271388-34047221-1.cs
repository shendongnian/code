    public class ProjectView
    {
        public int ProjectId { get; set; }    
        public string ProjectName { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public int AllottedHours{ get; set; }
        public int InvoicedHours { get; set; }
        public int UninvoicedHours { get; set; }
        public int RemainingHours { get; set; }
    }
