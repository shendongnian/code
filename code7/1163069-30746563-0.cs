    public interface IDatabaseConfiguration
    {
        string ConnectionString { get; }
    }
    public interface IBlogConfiguration
    {
        int NumberOfPostsPerPage { get; }
    }
    public class AppConfiguration : IDatabaseConfiguration, IBlogConfiguration
    {
        public string ConnectionString 
		{
			get { return ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString; }
		}
		
		public int NumberOfPostsPerPage 
		{
			get { return int.Parse(ConfigurationManager.AppSettings["PostsPerPage"]); }
		}
    }
