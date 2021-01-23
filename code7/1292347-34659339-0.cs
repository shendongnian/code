    public interface IReportSection
    {
        string ReportSectionName { get; }
    
        ICollection ReportItems { get; }
    }
    
    public abstract class ReportSectionBase<TRType> : IReportSection {
       ...
    } 
