    public class Researcher
    {
       public Researcher 
       {
         Submissions=new List<Submission>();
       }
       public int ResearcherId{get;set;}
       public string FirstName{get;set;}
       public string Surname{get;set;}
       public virtual ICollection<Submission> Submissions{get;set;}
    }
    public class Submission
    {
       public Submission
       {
         Researchers=new List<Researcher>();
       }
       public int SubmissionId{get;set;}
       public virtual ICollection<Researcher> Researchers{get;set;}
    }
