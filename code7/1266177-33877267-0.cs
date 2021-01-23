    public class Report : BaseReportModel
    {
        public Report()
        {
            StudentSummary = new StudentSummary
            {
                StudentDetails = new List<StudentDetails>()
            }
        }
        public StudentSummary StudentSummary { get; set; }
    }
