    public class Employee
	{
	    public long Id { get; set; }
		public virtual ICollection<EmployeeHistoryRecord> HistoryRecords { get; set; } 
	}
	public class EmployeeHistoryRecord
	{
		public long Id { get; set; }
		public DateTime ValidFrom { get; set; }
		public long EmployeeId { get; set; }
		public Employee Employee { get; set; }
	}
