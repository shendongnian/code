    public class SectionVM
    {
        public string Title{ get; set; }
        public List<SubSectionVM> SubSections { get; set; }
    }
    public class SubSectionVM
    {
        public string Title { get; set; }
        public List<QuestionVM> Questions { get; set; }
    }
    public class QuestionVM
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        ....
    }
