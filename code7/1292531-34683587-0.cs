    public class ReportBase
    {
        public ReportBase()
        {
            ReportSections = new List<IReportSection>();
        }
        public string ReportType { get; set; }
        public string ReportName { get; set; }
        public ICollection<IReportSection> ReportSections { get; set; }
        
    }
    public interface IReportSection
    {
        string ReportSectionName { get; }
        ICollection ReportItems { get; set; }
    }
    public class ReportSection<T> : IReportSection
    {
        public string ReportSectionName { get; set; }
        
        public ICollection<T> ReportItems { get; set; }
        ICollection IReportSection.ReportItems
        {
            get { return ReportItems as ICollection; }
            set { ReportItems = value as ICollection<T>; }
        }
    }
