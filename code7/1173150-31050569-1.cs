    public class Job
	{
		private string jobKey;
		private string jobValue;
        // Key property that will be displayed 
		public string JobKey
		{
			get { return jobKey; }
			set { jobKey = value; }
		}
        // Value property that will be displayed
		public string JobValue
		{
			get { return jobValue; }
			set { jobValue = value; }
		}
		public Job(string jobKey, string jobValue)
		{
			this.jobKey = jobKey;
			this.jobValue = jobValue;
		}
	}
