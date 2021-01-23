	public class Cluster
	{
		List<Cluster> lstChildClusters = new List<Cluster>();
	
		public List<Cluster> LstChildClusters
		{
			get { return lstChildClusters; }
			set { lstChildClusters = value; }
		}
		public classA alr;
	
		public List<classA> getLevel0Clusters()
		{
			return new[] { this.alr, }
				.Concat(this.LstChildClusters
					.SelectMany(child => child.getLevel0Clusters()))
				.ToList();
		}
	}
	
	public class classA
	{
		public string Name;
		public classA(string name)
		{
			this.Name = name;
		}
	}
