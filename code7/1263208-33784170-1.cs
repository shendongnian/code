    public class LineData
    {
        public string RowID { get; set; } = "";
        public bool MissingMatchingPunch { get; set; } = false;
        public bool ScheduleIssueWithPunches { get; set; } = false;
        // ....
    
        public LineData()
        {
            RowID = "";
            MissingMatchingPunch = false;
            ScheduleIssueWithPunches = false;
            // ...
        }
    }
