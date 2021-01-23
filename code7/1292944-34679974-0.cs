    public abstract class ReportBase
    {
        virtual public string ReportType { get; set; }
        virtual public string ReportName { get; set; }
        public ICollection<IReportSection> ReportSections { get; set; }
    }
    public interface IReportSection
    {
        string ReportSectionName { get; }
        ICollection ReportItems { get; set; }
    }
    public class ContribAuthorsReport : ReportBase
    {
        public ContribAuthorsReport()
        {
            ReportSections = new List<IReportSection>();
        }
        public override string ReportName { get { return "Contributing Affiliates' Contact Information"; } }
    }
    public class ChapterAffiliates : IReportSection
    {
        public string ReportSectionName { get { return "Chapter Affiliates"; } }
        public ICollection<ProjectSubmissionViewModel> ReportItems { get; set; }
        ICollection IReportSection.ReportItems {
            get { return ReportItems as ICollection; }
            set { ReportItems = value as ICollection<ProjectSubmissionViewModel>; }
        }
    }
