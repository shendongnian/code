    internal static ReportGenerationStatus GetReportsForSearch(string searchVal, string searchParam)
    {
        //code for your method
    }
    public class ReportGenerationStatus
    {
        public List<Contracts.DataContracts.Report> Result { get; set; }
        public bool HasResult { get; set; }
    }
