	public partial class _Default : Page
	{
		IProjectRepository projectRepository = new SPProjectRepository();
		protected void Page_Load(object sender, EventArgs e)
		{
			ProjectsRepeater.DataSource = projectRepository.GetProjects;
			ProjectsRepeater.DataBind();
		}
		public HomeViewModel ViewModel { get; set; }
	}
