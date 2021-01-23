    public abstract class ReportBase<TReportSection, TReportItem> where TReportSection : ReportSectionBase<TReportItem>
    {
        public virtual string ReportType { get; set; }
        public virtual string ReportName { get; set; }
        public ICollection<TReportSection> ReportSections { get; set; }
    }
    public abstract class ReportSectionBase<TReportItem>
    {
        public virtual string ReportSectionName { get; set; } 
        public ICollection<TReportItem> ReportItems { get; set; }
    }
    public class ChapterAffiliates : ReportSectionBase<ProjectSubmissionViewModel>
    {
        public override string ReportSectionName { get { return "Chapter Affiliates"; } }             
    }
    public class ContribAuthorsReport : ReportBase<ChapterAffiliates, ProjectSubmissionViewModel>
    {
        public ContribAuthorsReport()
        {
            ReportSections = new List<ChapterAffiliates>();
        }
        public override string ReportName { get { return "Contributing Affiliates' Contact Information"; } }
    }
