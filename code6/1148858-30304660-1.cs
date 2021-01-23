    [Route("/UpdateSyncStatus_EmployeeId_Timestamp", "POST")]
    public class UpdateSyncStatus_EmployeeId_Timestamp
    {
        public string EmployeeId { get; set; }
        public List<string> Timestamp { get; set; } 
    }
