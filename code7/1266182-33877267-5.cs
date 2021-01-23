    public class StudentSummary
    {
        public StudentSummary()
        {
            StudentDetails = new List<StudentDetails>();
        }
        public string Name { get; set; }
        public List<StudentDetails> StudentDetails { get; set; }
    }
