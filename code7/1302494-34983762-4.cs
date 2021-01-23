    namespace MyTest.Models
    {
        public class SchoolSubjectAppScore
        {
            public string Season { get; set; }
            public string year { get; set; }
        }
    
        public class SchoolSubject
        {
            public SchoolSubject() { this.AppScores = new List<SchoolSubjectAppScore>(); }
            public string Subject { get; set; }
            public List<SchoolSubjectAppScore> AppScores { get; set; }
        }
    }
