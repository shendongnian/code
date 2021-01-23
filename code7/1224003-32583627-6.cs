	public class PageInfo
	{
		public PageInfo()
		{
			CompanyId = Guid.Empty;
			BranchId = Guid.Empty;
			DepartmentId = Guid.Empty;
		}
	
		// VirtualPath should not have a leading slash
		// example: events/conventions/mycon
		public string VirtualPath { get; set; }
		public Guid CompanyId { get; set; }
		public Guid BranchId { get; set; }
		public Guid DepartmentId { get; set; }
	}
