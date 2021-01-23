    public abstract class ReportBase
    {
        virtual public string ReportType { get; set; }
        virtual public string ReportName { get; set; }
        public ICollection<ReportSectionBase> ReportSections { get; set; }
    }
    public abstract class ReportSectionBase<T>
    {
        virtual public string ReportSectionName { get; set; }
    
        virtual public ICollection<T> ReportItems { get; set; }
    }
    public class ChapterAffiliates : ReportSectionBase<ProjectSubmissionViewModel>
    {
        public override string ReportSectionName { get { return "Chapter Affiliates"; } }             
    }
