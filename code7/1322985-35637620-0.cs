     public class Application
        {
            public int Id { get; set; }
            public virtual ICollection<Applicant> Applicants { get; set; }
            public int? NumberOfEmployments { get; set; }
    
            public int GetNumberOfApplications()
            {
                return this.Applicants.SelectMany(x => x.Employments).Count();
            }
        }
