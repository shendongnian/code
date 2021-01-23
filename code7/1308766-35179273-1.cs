	public interface ILog
	{
		bool approved { get; set; }
		string approvedBy { get; set; }
	}
	public partial class ProductLog : ILog
	{
	}
	public partial class CategoryLog : ILog
	{
	}
	public partial class SubCategoryLog : ILog
	{
	}
