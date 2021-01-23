	public class ProjectList : List<Project>
	{
		public ProjectList() { }
		public ProjectList(IEnumerable<Project> projects)
			: this()
		{
			this.AddRange(projects);
		}
		
		public override string ToString()
		{
			return string.Format("Projects: {0}", this.Count());
		}
	}
