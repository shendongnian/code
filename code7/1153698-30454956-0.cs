    public class StageReportData
    {
        // Stage primary-key
        public int Id { get; set; }
        // More Stage data that is needed for the report
        // ...
        public Project Project { get; set; }
        public IEnumerable<Compfile> Compfiles { get; set; }
    }
