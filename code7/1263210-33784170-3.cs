    public class LineData
    {
        public string RowID { get; set; }
        public bool MissingMatchingPunch { get; set; }
        public bool ScheduleIssueWithPunches { get; set; }
        // ....
    
        public LineData()
        {
            RowID = "";
            MissingMatchingPunch = false;
            ScheduleIssueWithPunches = false;
            // ...
        }
    }
