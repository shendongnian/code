    public class Researcher
    {
       public Researcher 
       {
         ResearcherSubmissions=new List<ResearcherSubmission>();
       }
       public int ResearcherId{get;set;}
       public string FirstName{get;set;}
       public string Surname{get;set;}
       public virtual ICollection<ResearcherSubmission> ResearcherSubmissions{get;set;}
    }
    public class ResearcherSubmission
    {
        [Key, ForeignKey("Researcher"), Column(Order=1)]
        public int ResearcherId{get;set;}
        [Key, ForeignKey("Submission"), Column(Order=2)]
        public int SubmissionId {get;set;}
        public virtual Researcher Researcher{get;set;}
        public virtual Submission Submission {get;set;}
    }
    public class Submission
    {
       public Submission
       {
         ResearcherSubmissions=new List<ResearcherSubmission>();
       }
       public int SubmissionId{get;set;}
       public virtual ICollection<ResearcherSubmission> ResearcherSubmissions{get;set;}
    }
