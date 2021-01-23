    public class UserForm
    {
        public string UserFormId { get; set; }
        public bool IsComplete { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string FormId {get;set;}
        [ForeignKey("FormId")]
        public Form Form { get; set; }
    }
