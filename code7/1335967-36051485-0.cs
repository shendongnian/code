	public interface ISerializer
	{
		void Test();
	}
	public class ModelGenerator : ISerializer
	{
		private readonly IHttpContextAccessor httpContextAccessor;
		public ModelGenerator(IHttpContextAccessor httpContextAccessor)
		{
			this.httpContextAccessor = httpContextAccessor;
		}
		public void Test()
		{
			var context = this.httpContextAccessor.HttpContext;
			// Use the context
		}
	}
