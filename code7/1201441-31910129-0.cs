	public interface ISortByDate
	{
		DateTime SortByDate { get; }
	}
	
	public class ObjectA : ISortByDate
	{
		public DateTime CreateDate { get; set; }
		
		DateTime ISortByDate.SortByDate { get { return this.CreateDate; } }
	}
	
	public class ObjectB : ISortByDate
	{
		public DateTime DateCreated { get; set; }
		
		DateTime ISortByDate.SortByDate { get { return this.DateCreated; } }
	}
	
	public class ObjectC : ISortByDate
	{
		public DateTime DateOfCreation { get; set; }
		
		DateTime ISortByDate.SortByDate { get { return this.DateOfCreation; } }
	}
